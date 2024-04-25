using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public class Operations
    {
        public static UserDetails currentLoggedInUser;
        public static List<UserDetails> userList = new List<UserDetails>();
        public static List<BookDetails> bookList = new List<BookDetails>();
        public static List<BorrowDetails> borrowList = new List<BorrowDetails>();


        public static void MainMneu()
        {
            Console.WriteLine($"**********SYNCFUSION LIBRARY**********");
            int mainMenuOption;
            do{
                Console.WriteLine($"**********MAIN MENU**********");
                Console.WriteLine("1. User Registrarion\n2. User Login\n3. Exit");
                Console.Write($"Choose one option: ");
                mainMenuOption= int.Parse(Console.ReadLine());
                switch(mainMenuOption)
                {
                    case 1:
                    {
                        Console.WriteLine($"**********USER REGISTRATION**********");
                        UserRegistration();

                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine($"**********USER LOGIN**********");
                        UserLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine($"**********APPLICATION ENDED**********");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine($"**********INVALID OPTION**********");
                        break;
                    }
                }
            }while(mainMenuOption!=3);
            
        }//MainMneu ends here

        public static void UserRegistration()
        {
            Console.Write("Enter user name: ");
            string userName = Console.ReadLine();

            Gender gender;
            bool isValidGender;
            Console.Write("Enter user gender(Male/Female): ");
            do
            {
                isValidGender = Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
                if(!isValidGender) Console.Write("Invalid Gender\nEnter again in correct format: ");
            }while(!isValidGender);
            
            bool isValidDepartment;
            Department department;
            Console.Write("Enter user department(ECE, EEE, CSE): ");
            do
            {
                isValidDepartment = Enum.TryParse<Department>(Console.ReadLine(),true,out department);
                if(!isValidDepartment) Console.Write("Invalid Department\nEnter again in correct format: ");
            }while(!isValidDepartment);

            Console.Write("Enter user mobile number: ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter user mailID: ");
            string mailID = Console.ReadLine();
            Console.Write("Enter user wallet balance: ");
            bool isValidBalance;
            int walletBalance;
             do
            {
                isValidBalance = int.TryParse(Console.ReadLine(),out walletBalance);
                if(!isValidBalance) Console.Write("Invalid balance\nEnter again in numbers: ");
            }while(!isValidBalance);
            //int walletBalance = int.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(userName,gender,department,mobileNumber,mailID,walletBalance);
            userList.Add(user);
            Console.WriteLine($"Your registration has been successful.\nYour user ID is {user.UserID}");
            
        }//UserRegistration ends here

        public static void UserLogin()
        {
            
            Console.Write("Enter your User ID: ");
            string loginID = Console.ReadLine();
            bool isValidID = false;
            foreach(UserDetails user in userList)
            {
                if(loginID.Equals(user.UserID))
                {
                    isValidID=true;
                    currentLoggedInUser= user;
                    int subMenuOption;
                    do
                    {
                        Console.WriteLine("1. Borrowbook\n2. Show Borrow History\n3. Return Books\n4. WalletRecharge\n5. Exit");
                        Console.Write("Choose one option: ");
                        subMenuOption = int.Parse(Console.ReadLine());
                        switch(subMenuOption)
                        {
                            case 1:
                            {
                                Console.WriteLine("*********BORROW BOOK*********");
                                BorrowBook();
                                break;
                            }
                            case 2:
                            {
                                Console.WriteLine("*********SHOW BORROWED HISTORY*********");
                                ShowBorrowedHistory();
                                break;
                            }
                            case 3:
                            {
                                Console.WriteLine("*********RETURN BOOKS*********");
                                ReturnBooks();
                                break;
                            }
                            case 4:
                            {
                                Console.WriteLine("*********WALLET RECHARGE*********");
                                WalletRecharge();
                                break;
                            }
                            case 5:
                            {
                                Console.WriteLine("*********RETURNING TO MAIN MENU*********");
                                break;
                            }
                            default:
                            {
                                Console.WriteLine("*********INVALID OPTION*********");
                                break;
                            }
                        }
                    }while(subMenuOption!=5);
                }
            }
            if(isValidID==false)
            {
                Console.WriteLine("Invalid User ID or ID not present");
            }
            
        }//UserLogin ends here

        public static void BorrowBook()
        {
            Console.WriteLine("|Book ID|Book Name|Authour Name|Book count|");
            foreach(BookDetails book in bookList)
            {
                Console.WriteLine($"|{book.BookID}|{book.BookName}|{book.AuthorName}|{book.BookCount}|");
            }
            Console.Write("Select one book by entering book Id shown above:");
            string selectBookID = Console.ReadLine();
            bool checkBookCount=false;
            foreach(BookDetails book in bookList)
            {
                if(selectBookID.Equals(book.BookID))
                {
                    checkBookCount=true;
                    //enter count of book
                    
                    Console.Write("Enter the count of the book: ");
                    int selectBookCount = int.Parse(Console.ReadLine());
                    if(selectBookCount<=book.BookCount)
                    {
                        foreach(BorrowDetails borrow in borrowList)
                        {
                            if(currentLoggedInUser.UserID.Equals(borrow.UserID))
                            {
                                
                                //if book is avalibale check user has 3 books(show you have already 3 books)
                                int totalBookCount=0;
                                foreach(BorrowDetails borrow1 in borrowList)
                                {
                                    if(currentLoggedInUser.UserID.Equals(borrow1.UserID)&& borrow1.Status==Status.Borrowed)
                                    {
                                        totalBookCount+= borrow1.BorrowBookCount;
                                    }
                                    //Console.Write($"total: {totalBookCount}");
                                }
                                if(totalBookCount+selectBookCount<=3)
                                {
                                    //allocate book to user and set staus of booking detail as borrowed and set borrowed date and add paid fine amiunt as 0.
                                    BorrowDetails borrowRecent = new BorrowDetails(book.BookID, currentLoggedInUser.UserID,DateTime.Now,selectBookCount,Status.Borrowed,0);
                                    borrowList.Add(borrowRecent);

                                    Console.WriteLine($"Book borrowed successfully.\nYour borrow ID is {borrowRecent.BorrowID}");
                                    Console.WriteLine($"Now you have {totalBookCount+selectBookCount} books.");
                                    borrowRecent.BorrowBookCount += selectBookCount;
                                    book.BookCount -= selectBookCount;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {totalBookCount} and requested count is {selectBookCount}, which exceeds 3");
                                    break;
                                }
                            }

                        }
                    }
                    else
                    {
                        //check available book count if not available print available date
                        Console.WriteLine("Books are not available for the selected count");
                        DateTime availableDate = DateTime.Now;
                        DateTime minimumDate = DateTime.MaxValue;
                        foreach(BorrowDetails borrow in borrowList)
                        {
                            if(book.BookID.Equals(borrow.BookID))
                            {
                                if(borrow.BorrowDate<minimumDate)
                                {
                                    availableDate= borrow.BorrowDate.AddDays(15);
                                    break;
                                }
                            }
                        }
                        Console.WriteLine($"The book will be available on {availableDate} ");
                        
                    }
                }
            }
            if(checkBookCount==false)
            {
                Console.WriteLine("Invalid Book ID!");
            }
            

        }//BorrowBook ends here

        public static void ShowBorrowedHistory()
        {
            bool flag = false;
            bool borrowTopic= false;
            foreach(BorrowDetails borrow in borrowList)
            {
                if(currentLoggedInUser.UserID.Equals(borrow.UserID))
                {
                    flag = true;
                    if(borrowTopic==false)
                    {
                        Console.WriteLine("|Borrow ID|Book ID|User ID|Borrow Date|Borrow Book Count|Status|Paid Fine Amount|");
                        borrowTopic=true;
                    }
                    Console.WriteLine($"|{borrow.BorrowID,10}|{borrow.BookID,10}|{borrow.UserID,10}|{borrow.BorrowDate.ToShortDateString(),10}|{borrow.BorrowBookCount,10}|{borrow.Status,10}|{borrow.PaidFineAmount,10}|");
                }
            }
            if(flag == false)
            {
                Console.WriteLine("You have no borrowed books.");
            }
        }//ShowBorrowedHistory ends here

        public static void ReturnBooks()
        {
            //Show borrowed book list of current user whose status is borrowed also print return date
            
            ShowBorrowedHistory();

            // if return date more than 15 days add fine
            bool flagborrowID= false;
            foreach(BorrowDetails borrow in borrowList)
            {
                
                //select borrowed id and validate
            
                if(currentLoggedInUser.UserID.Equals(borrow.UserID) && borrow.Status==Status.Borrowed)
                {
                   Console.Write("Enter BorrowID to return a book: ");
                   string selectBorrowID = Console.ReadLine();
                   if(selectBorrowID.Equals(borrow.BorrowID))
                   {
                    flagborrowID=true;
                    //if return date is more than 15 days check balance
                    DateTime returnDate = borrow.BorrowDate.AddDays(15);

                    TimeSpan fineDays = DateTime.Now - returnDate;
                    
                    double finedAmount;
                    if(fineDays.TotalDays>15)
                    {
                        finedAmount = fineDays.TotalDays -15;
                        if(currentLoggedInUser.WalletBalance>=finedAmount)
                        {
                            currentLoggedInUser.DeductBalance(finedAmount);
                            borrow.Status = Status.Returned;
                            borrow.PaidFineAmount= finedAmount;
                            Console.WriteLine($"Book returned Successfully");
                            foreach(BookDetails book in bookList)
                            {
                                if(borrow.BookID==book.BookID)
                                {
                                    book.BookCount+=borrow.BorrowBookCount;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Insufficient balance. Please rechange and proceed");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Book returned Successfully");
                        borrow.Status = Status.Returned;
                            foreach(BookDetails book in bookList)
                            {
                                if(borrow.BookID==book.BookID)
                                {
                                    book.BookCount+=borrow.BorrowBookCount;
                                }
                            }
                    }
                    //Console.WriteLine($" days: {Math.Abs(totalDays.TotalDays)}");


                    //totalDays = totalDays.TotalDays;

                    //if has sufficient balance deduct fine and change status to returned add show retuened success
                    // Update book count
                   }
                }
            }
            if(flagborrowID==false)
                {
                    Console.WriteLine("Invalid Borrow ID!");
                }
            
            

        }//ReturnBooks ends here

        public static void WalletRecharge()
        {
            Console.Write("Enter amount to recharge: ");
            int rechargeAmount = int.Parse(Console.ReadLine());
            currentLoggedInUser.WalletRecharge(rechargeAmount);


        }//WalletRecharge ends here

        public static void AddingDefaultData()
        {

            UserDetails user1 = new UserDetails(	"Ravichandran" 	,Gender.Male	,Department.EEE	,"9938388333",	"ravi@gmail.com",100);
            UserDetails user2 = new UserDetails(	"Priyadharshini"	,Gender.Female,	Department.CSE	,"9944444455",	"priya@gmail.com",150);
            userList.Add(user1);
            userList.Add(user2);

            BookDetails book1= new BookDetails(	"C# "	,"Author1",	3);
            BookDetails book2= new BookDetails("HTML",	"Author2",	5);
            BookDetails book3= new BookDetails(	"CSS",	"Author1",	3);
            BookDetails book4= new BookDetails("JS",	"Author1",	3);
            BookDetails book5= new BookDetails(	"TS",	"Author2",	2);
            bookList.Add(book1);
            bookList.Add(book2);
            bookList.Add(book3);
            bookList.Add(book4);
            bookList.Add(book5);

            BorrowDetails borrow1= new BorrowDetails("BID1001",	"SF3001",	new DateTime(2023,09,10),	2	,Status.Borrowed	,0);
            BorrowDetails borrow2= new BorrowDetails("BID1003",	"SF3001", new DateTime(2023,09,12)	,	1	,Status.Borrowed,	0);
            BorrowDetails borrow3= new BorrowDetails("BID1004",	"SF3001", new DateTime(2023,09,14),	1,	Status.Returned	,16);
            BorrowDetails borrow4= new BorrowDetails("BID1002",	"SF3002" ,new DateTime(2023,09,11),	2,	Status.Borrowed	,0);
            BorrowDetails borrow5= new BorrowDetails("BID1005"	,"SF3002"	,new DateTime(2023,09,09),1	,Status.Returned	,20);

            borrowList.Add(borrow1);
            borrowList.Add(borrow2);
            borrowList.Add(borrow3);
            borrowList.Add(borrow4);
            borrowList.Add(borrow5);

        }//AddingDefaultData ends here
    }



}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("LibraryManagement"))
            {
                Directory.CreateDirectory("LibraryManagement");
                Console.WriteLine($"folder Created.");
            }
            if(!File.Exists("LibraryManagement/UserDetails.csv"))
            {
                File.Create("LibraryManagement/UserDetails.csv");
                Console.WriteLine($"UserDetails.csv created.");
            }
            if(!File.Exists("LibraryManagement/BookDetails.csv"))
            {
                File.Create("LibraryManagement/BookDetails.csv");
                Console.WriteLine($"BookDetails.csv created.");
            }
            if(!File.Exists("LibraryManagement/BorrowDetails.csv"))
            {
                File.Create("LibraryManagement/BorrowDetails.csv");
                Console.WriteLine($"BorrowDetails.csv created.");
            }
        }

        public static void WriteToCSV()
        {
            string[] users = new string[Operations.userList.Count];
            for(int i = 0; i< Operations.userList.Count; i++)
            {
                users[i] = Operations.userList[i].UserID+","+Operations.userList[i].UserName+","+Operations.userList[i].Gender+","+Operations.userList[i].Department+","+Operations.userList[i].MobileNumber+","+Operations.userList[i].MailID+","+Operations.userList[i].WalletBalance;
            }
            File.WriteAllLines("LibraryManagement/UserDetails.csv",users);
            //BookDetails
            string [] books = new string[Operations.bookList.Count];
            for(int i =0; i<Operations.bookList.Count; i++)
            {
                books[i] = Operations.bookList[i].BookID+","+Operations.bookList[i].BookName+","+Operations.bookList[i].AuthorName+","+Operations.bookList[i].BookCount;
            }
            File.WriteAllLines("LibraryManagement/BookDetails.csv",books);

            //BorrowDetails
            string[] borrows = new string[Operations.bookList.Count];
            for(int i =0;i<Operations.bookList.Count; i++ )
            {
                borrows[i] = Operations.borrowList[i].BorrowID+","+Operations.borrowList[i].BookID+","+Operations.borrowList[i].UserID+","+Operations.borrowList[i].BorrowDate.ToString("dd/MM/yyyy")+","+Operations.borrowList[i].BorrowBookCount+","+Operations.borrowList[i].Status+","+Operations.borrowList[i].PaidFineAmount;
            }
            File.WriteAllLines("LibraryManagement/BorrowDetails.csv",borrows);
        }

        public static void ReadFromCSV()
        {
            string[] users = File.ReadAllLines("LibraryManagement/UserDetails.csv");
            foreach(string user in users)
            {
                UserDetails user1 = new UserDetails(user);
                Operations.userList.Add(user1);
            }

            //BookDetails
            string [] books = File.ReadAllLines("LibraryManagement/BookDetails.csv");
            foreach(string book in books)
            {
                BookDetails book1 = new BookDetails(book);
                Operations.bookList.Add(book1);
            }

            //borrowDetails
            string[] borrows = File.ReadAllLines("LibraryManagement/BorrowDetails.csv");
            foreach(string borrow in borrows)
            {
                BorrowDetails borrow1 = new BorrowDetails(borrow);
                Operations.borrowList.Add(borrow1);
            }
        }
    }
}
using System; 
using System.Collections.Generic;
namespace EBBillCalculation;
class Program{
    public static void Main(string[] args)
    {
        List <BillBalculation> billList= new List<BillBalculation>();
        int mainMenuOption;
        string newRegister;
        int subMenuOption;
        do{
            Console.WriteLine("1.Registration\n2.Login\n3.Exit");
            mainMenuOption= int.Parse(Console.ReadLine());
            switch(mainMenuOption)
            {
                case 1:
                {
                    do{
                    Console.Write("Username: ");
                    string userName= Console.ReadLine();
                    Console.Write("Phone number: ");
                    long phone = long.Parse(Console.ReadLine());

                    Console.Write("MailID: ");
                    string mail = Console.ReadLine();

                    BillBalculation bill = new BillBalculation(userName, phone, mail);
                    billList.Add(bill);
                    Console.WriteLine($"Your MeterId : {bill.MeterId}");
                    Console.WriteLine("Do you want to add another user: (yes/no)");
                    newRegister=Console.ReadLine();
                    }while(newRegister=="yes");
                    break;
                }

                case 2:
                {
                    Console.WriteLine("Enter your MeterId");
                    string meterId = Console.ReadLine();
                    foreach(BillBalculation bill in billList)
                    {
                        if(meterId==bill.MeterId)
                        {
                            do{
                                Console.WriteLine("1.Calcluate Amount\n2.Display user Details\n3.Exit");
                                subMenuOption= int.Parse(Console.ReadLine());
                                switch(subMenuOption)
                                {
                                    case 1 :
                                    {
                                        Console.Write("Enter units used: ");
                                         bill.UnitsUsed = int.Parse(Console.ReadLine());
                                         bill.CalculateAmount();
                                         Console.WriteLine($"Your bill ID : {bill.BillId}");
                                         Console.WriteLine($"User name: {bill.UserName}");
                                         Console.WriteLine($"Used units: {bill.UnitsUsed}");
                                         Console.WriteLine($"Your bill is {bill.TotalAmount}");
                                        break;
                                    }
                                    case 2 :
                                    {
                                        Console.WriteLine("User Details");
                                        Console.WriteLine($"Your Meter ID : {bill.MeterId}");
                                        Console.WriteLine($"User name: {bill.UserName}");
                                        Console.WriteLine($"Phone Number: {bill.Phone}");
                                        Console.WriteLine($"Mail Id: {bill.MailId}");
                                        Console.WriteLine($"Bill id");
                                        break;
                                    }
                                    case 3 :
                                    {
                                        Console.WriteLine("Returned to Main Menu!");
                                        break;
                                    }
                                    default :
                                    {
                                        break;
                                    }
                                }
                                

                            }while(subMenuOption!=3);
                        }
                        else 
                        Console.WriteLine("Invalid Meter ID");
                    }
                    break;
                }

                case 3:
                {
                    Console.WriteLine("Application Ended");
                    break;
                }

                default:
                {
                    break;
                }
            }

        }while(mainMenuOption!=3);
    }

}
using System;
using System.Collections.Generic; 
namespace BankAccountOpening;
class Program{
    public static void Main(string[] args)
    {
        
        string customerId;
        string customerName;
        string balance;
        string gender;
        string phone;
        string mail;
        string dob;
        int currentBalance=0;
        List<string> customerDetails =new List<string>();
        
        Console.WriteLine("Menu");
        Console.WriteLine("1.Registration");
        Console.WriteLine("2.Login");
        Console.WriteLine("3.Exit");
        int menuOption = int.Parse(Console.ReadLine());
        switch(menuOption)
        {
            case 1:
            {
                Console.WriteLine("Registration");
                
                //customerDetails = AddDetails();
                Console.Write("Enter your CustomerId: ");
                customerId = Console.ReadLine();
                Console.Write("Enter your name: ");
                 customerName = Console.ReadLine();
                Console.Write("Enter your Balance: ");
                 balance = Console.ReadLine();
                Console.Write("Enter your Gender: ");
                 gender = Console.ReadLine();
                Console.Write("Enter your Phone number: ");
                 phone = Console.ReadLine();
                Console.Write("Enter your MailID: ");
                 mail = Console.ReadLine();
                Console.Write("Enter your Date of birth: ");
                 dob = Console.ReadLine();
                customerDetails.Add(customerId);
                customerDetails.Add(customerName);
                customerDetails.Add(balance);
                currentBalance = int.Parse(balance);
                customerDetails.Add(gender);
                customerDetails.Add(phone);
                customerDetails.Add(mail);
                customerDetails.Add(dob);
                foreach(string item in customerDetails)
                {
                    Console.WriteLine(item);
                }
                break;

            }
            case 2:
            {
            Console.WriteLine("Enter your CustomerId");
            string loginID = Console.ReadLine();
            if(loginID==customerDetails[0])
            {
                Console.WriteLine("1.Deposit");
                Console.WriteLine("2.Withdraw");
                Console.WriteLine("3.Balance Check");
                Console.WriteLine("4.Exit");
                
                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        Console.Write("Enter deposit amount: ");
                        int amount=int.Parse(Console.ReadLine());
                        currentBalance+=amount;
                        break;
                    }
                    case 2:
                    {
                        Console.Write("Enter withdraw amount: ");
                        int amount=int.Parse(Console.ReadLine());
                        currentBalance-=amount;
                        break;
                    }
                    case 3:
                    {
                        Console.Write($"Your Balance: {currentBalance}");
                        break;
                    }
                    case 4:
                    {
                        
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid Option");
                        break;
                    }
                    
                }
            }
            else Console.WriteLine("Invalid user ID");
            break;
            }
            case 3:
            {
                //Console.ReadKey();
                Console.WriteLine("Exited from the apllication");
                break;
            }
            default:
            {
                Console.WriteLine("Invalid Option");
                break;
            }
        }

        }
    }
    enum Gender
    {
        Male=1,
        Female=2,
        Other =3
    }

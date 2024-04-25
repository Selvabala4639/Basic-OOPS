using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Banking;

public enum Gender{Select , Male, Female, Transgender} 
class Program{
    public static void  Main(string[] args)
    {
        List<CustomerDetails> customerList = new List<CustomerDetails>();
        //int total;
        //string homeOption;
        int menuOption;
        do{
        Console.WriteLine("Menu");
        Console.WriteLine("1.Registration");
        Console.WriteLine("2.Login");
        Console.WriteLine("3.Exit"); 
         menuOption = int.Parse(Console.ReadLine());
        string choice;
        switch(menuOption)
        {
            case 1:
            {
                do{
                    Console.WriteLine("Registration");
                    
                    //CustomerDetails customer = new CustomerDetails();

                    //customerDetails = AddDetails();
                    // Console.Write("Enter your CustomerId: ");
                    // string customerID = Console.ReadLine();
                    Console.Write("Enter your name: ");
                    string customerName = Console.ReadLine();
                    Console.Write("Enter your Balance: ");
                    int balance = int.Parse(Console.ReadLine());
                    Console.Write("Enter your Gender as shown below:\n\tMale\n\tFemale\n\tTransgender\n");
                    Gender gender= Enum.Parse<Gender>(Console.ReadLine());
                    //Gender gender = (Gender)genderValue;  
                   
                    
                    Console.Write("Enter your Phone number: ");
                    long phone = long.Parse(Console.ReadLine());
                    Console.Write("Enter your MailID: ");
                    string mailID = Console.ReadLine();
                    Console.Write("Enter your Date of birth: ");
                    DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    
                    CustomerDetails customer = new CustomerDetails( customerName, balance, gender, phone, mailID, dob);
                    Console.WriteLine("Do you want to add new customer: (yes/no)");
                    choice =Console.ReadLine();
                    customerList.Add(customer);
                }while(choice=="yes");
                 break;
            }
            case 2:
            {
                int subMenuOption;
                Console.WriteLine("Enter your customer ID:");
                string loginID = Console.ReadLine();
                foreach(CustomerDetails customer in customerList)
                {
                    if(customer.CustomerID==loginID)
                    {
                        do
                        {
                            Console.WriteLine("###################################\n");
                            Console.WriteLine($"Hi {customer.CustomerName}");
                            Console.WriteLine("\n###################################");
                            Console.WriteLine("1.Deposit\n2.Withdraw\n3.Balance Check\n4.Exit (Return to main menu)");
                            subMenuOption= int.Parse(Console.ReadLine());
                            switch(subMenuOption)
                            {
                                case 1:
                                {
                                    Console.Write("Enter deposit amount : ");
                                    int depositAmount = int.Parse(Console.ReadLine());
                                    customer.Balance = customer.Deposit(depositAmount, customer.Balance);
                                    break;
                                }
                                case 2:
                                {
                                    Console.Write("Enter Withdraw amount : ");
                                    int withdrawAmount = int.Parse(Console.ReadLine());
                                    customer.Balance = customer.Withdraw(withdrawAmount, customer.Balance);
                                    break;
                                }
                                case 3:
                                {
                                    Console.WriteLine("-----------------------------------\n\n");
                                    Console.WriteLine($"Your Balance is {customer.Balance}.");
                                    Console.WriteLine("\n\n-----------------------------------");
                                    break;
                                }
                                case 4:
                                {
                                    Console.WriteLine("-----------------------------------\n");
                                    Console.WriteLine($"Returned to Main Menu");
                                    Console.WriteLine("\n-----------------------------------");
                                    break;
                                }
                                default:
                                {
                                    Console.WriteLine("Invalid Option!!!");
                                    break;
                                }
                            }
                        }while(subMenuOption!=4);
                        break;
                    }
                    else{
                        Console.WriteLine("Invalid user ID");
                    }
                }
                break;
            }
            case 3:
            {
                Console.WriteLine("-----------------------------------\n\n");
                Console.WriteLine($"You have exited the application.");
                Console.WriteLine("\n\n-----------------------------------");
                break;
            }
            default:
            {
                Console.WriteLine("Invalid Option");
                break;
            }
        }
        // Console.WriteLine("Do you want to return to home page: (yes/no)");
        // homeOption = Console.ReadLine();
    }while(menuOption!=3);
    }
}
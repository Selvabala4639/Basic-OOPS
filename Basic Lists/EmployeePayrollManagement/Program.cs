using System;
using System.Collections.Generic;
namespace EmployeePayrollManagement;

class Program{

    
    public static void Main(string[] args)
    {
        List <EmployeeDetails> EmployeeList = new List<EmployeeDetails>();
        string registerOption;
        int menuOption;
        //int salary=0;
        int subMenuOption;
        do{
            MainMenu();
            menuOption = int.Parse(Console.ReadLine());
            switch(menuOption)
            {
                case 1:
                {
                    do{
                    Console.WriteLine("-----------------------------------\n\n");
                    Console.WriteLine("\tRegistration");
                    Console.WriteLine("\n\n-----------------------------------");

                    Console.Write("Enter employee name : ");
                    string employeeName = Console.ReadLine();

                    Console.Write("Enter employee role : ");
                    string employeeRole = Console.ReadLine();

                    Console.WriteLine("Enter employee work location as given below: ");
                    Console.WriteLine("\tChennai\n\tBengaluru");
                    Location location = Enum.Parse<Location>(Console.ReadLine());

                    Console.Write("Team name : ");
                    string teamName = Console.ReadLine();

                    Console.Write("Date of joining : ");
                    DateTime doj = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

                    Console.Write("Number of Working Days in Month : ");
                    int workDays = int.Parse(Console.ReadLine());

                    Console.Write("Number of Leave Taken : ");
                    int leaveTaken = int.Parse(Console.ReadLine());

                    Console.Write("Enter your Gender as shown below:\n\tMale\n\tFemale\n\tTransgender\n");
                    Gender gender = Enum.Parse<Gender>(Console.ReadLine());

                    EmployeeDetails employee1 = new EmployeeDetails(employeeName,employeeRole,location,teamName,doj,workDays,leaveTaken,gender);
                    EmployeeList.Add(employee1);
                    Console.WriteLine("Do you want to add another employee details: (yes/no)");
                    registerOption=Console.ReadLine();
                    }while(registerOption=="yes");
                    break;
                }

                case 2:
                {

                    Console.Write("Enter EmployeeID to Login: ");
                    string loginID = Console.ReadLine();
                    foreach(EmployeeDetails employee in EmployeeList)
                    {
                        if(loginID==employee.EmployeeID)
                        {
                            do
                            {
                                Console.WriteLine("###################################");
                                Console.WriteLine($"Hi {employee.EmployeeName}");
                                Console.WriteLine("###################################");
                                Console.WriteLine("1.Calculate Salary\n2.Display Employee Details\n3.Exit (Return to main menu)");
                                subMenuOption= int.Parse(Console.ReadLine());
                                switch(subMenuOption)
                                {
                                    case 1:
                                    {
                                         employee.CalculateSalary();
                                         Console.WriteLine($"Employee Salary = {employee.Salary}");
                                        break;
                                    }
                                    case 2:
                                    {
                                        Console.WriteLine($"Employee ID : {employee.EmployeeID}");
                                        Console.WriteLine($"Employee Name : {employee.EmployeeName}");
                                        Console.WriteLine($"Employee Role : {employee.EmployeeRole}");
                                        Console.WriteLine($"Employee Location : {employee.EmployeeLocation}");
                                        Console.WriteLine($"Employee Team Name : {employee.TeamName}");
                                        string doj = employee.DOJ.ToString("dd/MM/yyyy");
                                        Console.WriteLine($"Employee Date of Joining : {doj}");
                                        Console.WriteLine($"Number of Days worked : {employee.WorkDays}");
                                        Console.WriteLine($"Leave Taken : {employee.LeaveTaken}");
                                        Console.WriteLine($"Employee Gender : {employee.Gender}");
                                        if (employee.Salary==0) Console.WriteLine("First you have to calculate Salary!!");
                                        else
                                        Console.WriteLine($"Employee salary = {employee.Salary}");
                                        break;
                                    }
                                    case 3:
                                    {
                                        Console.WriteLine("Returned to Main Menu");
                                        break;
                                    }
                                    default:
                                    {
                                        break;
                                    }
                                }
                            }while(subMenuOption!=3);
                        }
                        else Console.WriteLine("Invalid user ID.");
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
                    Console.WriteLine("Invalid Option!!!");
                    break;
                }

            }
            


        }while(menuOption!=3);
        


    }

    static void MainMenu()
    {
        Console.WriteLine("1.Registration\n2.Login\n3.Exit");
    }

}
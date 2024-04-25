using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagement
{
    public static class Operations
    {
        public static EmployeeDetails currentLoggedInUser;
         public static List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
        public static List<AttendenceDetails> attendenceList = new List<AttendenceDetails>();
        public static void MainMenu()
        {
            int mainmenuOption;
            do
            {
                Console.WriteLine($"1.Register\n2.Login\n3.Exit");
                mainmenuOption = int.Parse(Console.ReadLine());
                switch(mainmenuOption)
                {
                    case 1:
                    {
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine($"Application ended");
                        
                        break;
                    }
                }
                
            }while(mainmenuOption!=3);
        }

        public static void Registration()
        {
            Console.Write("Enter employee name : ");
            string name = Console.ReadLine();

            Console.Write("DOB: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter mobile number : ");
            string mobile = Console.ReadLine();
            Console.WriteLine($"Enter Gender as shown below:\nMale\nFemale");
            
            Gender gender = Enum.Parse<Gender>(Console.ReadLine());

            Console.WriteLine($"Enter Branch as shown below: \nEymard\nKaruna\nMathura");
            Branch branch = Enum.Parse<Branch>(Console.ReadLine());
            Console.Write($"Enter Team as shown below \n Network, Hardware, Developer, Facility");
            Team team = Enum.Parse<Team>(Console.ReadLine());
            EmployeeDetails employee = new EmployeeDetails(name,dob, mobile,gender,branch,team);
            employeeList.Add(employee);
        }
        public static void Login()
        {
            Console.Write($"Enter Login id:");
            string loginId = Console.ReadLine();
            bool flag = false;
            foreach(EmployeeDetails employee in employeeList)
            {
                if(loginId.Equals(employee.EmployeeID))
                {
                    flag = true;
                    currentLoggedInUser = employee;
                    Console.WriteLine($"Login Successful");
                    int subMenuOption;
                    do{
                        Console.WriteLine($"1.Add attendence\n2.Display Details\n3.Calculate Salary\n4.Exit");
                        subMenuOption = int.Parse(Console.ReadLine());
                        switch(subMenuOption)
                        {
                            case 1:
                            {
                                AddAttendence();
                                break;
                            }
                            case 2:
                            {
                                DisplayDetails();
                                break;
                            }
                            case 3:
                            {
                                CalculateSalary();
                                break;
                            }
                            case 4:
                            {
                                Console.WriteLine($"Returning to main menu");
                                
                                break;
                            }
                        }
                    }while(subMenuOption!=4);
                    
                }
            }
            if(flag == false) Console.WriteLine($"Invalid login ID");
            
        }

        public static void AddAttendence()
        {
            Console.Write($"Do you want to check in(yes/no)");
            string checkinOption = Console.ReadLine();
            if(checkinOption=="yes")
            {
                Console.Write($"Enter date:");
                DateTime checkinDate = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                Console.Write($"Enter time:");
                TimeOnly  checkinTime = TimeOnly.ParseExact(Console.ReadLine(),"HH:mm",null);
                Console.Write($"Do you want to check out(yes/no)");
                string checkoutOption = Console.ReadLine();
                if(checkoutOption=="yes")
                {
                    Console.Write($"Enter date:");
                    DateTime checkoutDate = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    Console.Write($"Enter time:");
                    TimeOnly  checkoutTime = TimeOnly.ParseExact(Console.ReadLine(),"HH:mm",null);
                    TimeSpan worked = checkoutTime- checkinTime;
                    //double hoursWorked = worked.Hours;
                    if(worked.Hours>8)
                    {
                        AttendenceDetails attendence = new AttendenceDetails(currentLoggedInUser.EmployeeID,checkinDate,checkinTime,checkoutTime,8);
                        attendenceList.Add(attendence);
                        Console.WriteLine($"Check-in and Checkout Successful and today you have worked 8 Hours");
                    }
                }
            }
        }
        public static void DisplayDetails()
        {
            currentLoggedInUser.ShowEmployeeDetails();
        }
        public static void CalculateSalary()
        {
            double totalHours=0;
            foreach(AttendenceDetails attendence in attendenceList)
            {
                if(attendence.Date.Month.Equals(DateTime.Today.Month))
                {
                    totalHours += attendence.HoursWorked;
                }
            }
            double salary = totalHours*500/8;
            Console.WriteLine($"Salary: {salary}");
        }
        public static void AddingDefaultDate()
        {
            EmployeeDetails employee= new EmployeeDetails("Ravi"	,new DateTime(1999,11,11)	,"9958858888"	,Gender.Male,	Branch.Eymard,	Team.Developer);
            employeeList.Add(employee);

            AttendenceDetails attendence  = new AttendenceDetails("SF3001", new DateTime(2022,05,15) , new TimeOnly(09,00,00)  , new TimeOnly(18,30,00),8);
            attendenceList.Add(attendence);
            // Console.WriteLine($"{attendence.CheckInTime}");
            // Console.WriteLine($"{attendence.CheckOutTime}");
            
        }
    }

    
}
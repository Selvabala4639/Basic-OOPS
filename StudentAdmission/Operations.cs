using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //Static class
    public static class Operations
    {
        //Local/Global Object creation
        static StudentDetails currentLoggedInStudent;
        static string line ="________________________________________________";
        //Static List Creation
        public static List<StudentDetails> studentList = new List<StudentDetails>();
        public static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        public static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();

        //Maibn Menu
        public static void MainMenu()
        {
            Console.WriteLine("**********Welcome to Syncfusion College of Engineering and Technology**********");
            string mainChoice;
            do
            {
                //Need  to show main menu option.
                Console.WriteLine("Main Menu\n1.Registration\n2.Login\n3.Department wise seat availablity\n4.Exit");
                //Need to get an input from user and validate.
                Console.Write("Select an option: ");
                int mainMenuOption = int.Parse(Console.ReadLine());
                 mainChoice = "yes";
                //Need to create main menu structure.
                switch(mainMenuOption)
                {
                    case 1:
                    {
                        Console.WriteLine("************Student Registration************");
                        StudentRegistration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("************Student Login************");
                        StudentLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("************Department wise seat availablity************");
                        DepartmentWiseSeatAvailablity();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("************Application exited Successfully************");
                        mainChoice="no";
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid Main Menu Option");
                        break;
                    }
                }
            //Need to iterate util the option is exit.
            }while(mainChoice=="yes");
        }//Main Menu ends

        //Student Registration method
        public static void StudentRegistration()
        {
            //Need to get required details
            
            Console.Write("Enter your Full Name: ");
            string studentName = Console.ReadLine();
            Console.Write("Enter  your Father Name: ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your Date of Birth: ");
            DateTime dob;
            bool isValidDate;
            do{
            isValidDate = DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null, System.Globalization.DateTimeStyles.None, out dob);
            if(!isValidDate) Console.Write("Enter a valid date in the format: dd/MM/yyyy: ");
            }while(!isValidDate);
            
            Console.Write("Enter your Gender as specified:\n\tMale\n\tFemale\n\tTransgender\nGender:");
            Gender gender  = Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your Physics Mark: ");
            int physicsMark = int.Parse(Console.ReadLine());
            Console.Write("Enter your chemistry Mark: ");
            int chemistryMark = int.Parse(Console.ReadLine());
            Console.Write("Enter your Maths Mark: ");
            int mathsMark = int.Parse(Console.ReadLine());
            
            //Need to create an object
            StudentDetails student = new StudentDetails(studentName,fatherName,dob,gender,physicsMark,chemistryMark,mathsMark);
            //Need to add in the List
            studentList.Add(student);
            //Need to display confirmation message and ID
            Console.WriteLine($"\nStudent Registered Successfully and StudentID is {student.StudentID}\n");
        }

        //Student Login method
        public static void StudentLogin()
        {
            //Need to get ID input
            Console.Write("Enter your student ID: ");
            string loginID = Console.ReadLine().ToUpper();
            //Validate loginId 
            //Check whether entered loginID is present in List
            bool flag =true;
            foreach(StudentDetails student in studentList)
            {
                if(loginID.Equals(student.StudentID))
                {
                    flag=false;
                    //Assgining current student object to global student object
                    currentLoggedInStudent = student; 
                    Console.Write("Logged in successfully");
                    SubMenu();
                    break;  
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid User ID or ID is not present");
            }
            //If login Id not in List
        }//Login ends

        //subMenu Method
        public static void SubMenu()
        {
            string subMenuOption;
            do
            {
                //Need to show sub menu options
                //Getting user options
                //Iterate still option is exit
                Console.WriteLine("\n************Sub Menu************\n");
                Console.WriteLine("a.Check eligibility\nb.Show Details\nc.Take admission\nd.Cancel Admission\ne.Show Admission Details\nf.Exit");
                Console.Write("Enter an option: ");
                subMenuOption = (Console.ReadLine());
                switch(subMenuOption)
                {
                    case "a":
                    {
                        Console.WriteLine("\n************Check Eligibility************\n");
                        CheckEligibility();
                        break;
                    }
                    case "b":
                    {
                        Console.WriteLine("\n************Show Details************\n");
                        ShowDetails();
                        break;
                    }
                    case "c":
                    {
                        Console.WriteLine("\n************Take Admission************\n");
                        TakeAdmission();
                        break;
                    }
                    case "d":
                    {
                        Console.WriteLine("\n************Cancel Admission************\n");
                        CancelAdmission();
                        break;
                    }
                    case "e":
                    {
                        Console.WriteLine("\n************Show Admission Details************\n");
                        ShowAdmissionDetails();
                        break;
                    }
                    case "f":
                    {
                        Console.WriteLine("\n************Taking back to Main Menu************\n");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("\nInvalid sub menu option\n");
                        break;
                    }
                }
            }while(subMenuOption!="f");
        }//SubMenu ends here

        //CheckEligibility method starts here
        public static void CheckEligibility()
        {
            //Get the cutoff value as input
            //Check eligible or not
            Console.Write("Enter cutoff value: ");
            double cutOff= double.Parse(Console.ReadLine());
            if(currentLoggedInStudent.CheckEligiblity(cutOff))  Console.WriteLine("Student is eligible:-)");
            else Console.WriteLine("Student is not eligible:-(");
        }//CheckEligibility ends here

        //ShowDetails method starts here
        public static void ShowDetails()
        {
            //need to show current logged in student details
            Console.WriteLine("|Student Name|Father Name|Student DOB|Student gender|Physics Mark|Chemistry Mark|Maths Mark");
            Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB.ToShortDateString()}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMark}|{currentLoggedInStudent.ChemistryMark}|{currentLoggedInStudent.MathsMark}|");
        }//ShowDetails ends here

        //TakeAdmission method starts here
        public static void TakeAdmission()
        {
            //Need to show available department details
            DepartmentWiseSeatAvailablity();
            //Ask department ID from user
            Console.Write("Select a department ID: ");
            string departmentID = Console.ReadLine().ToUpper();
            bool flag = true;
             // Check the ID is present or not
            foreach(DepartmentDetails department in departmentList)
            {
                if(departmentID.Equals(department.DepartmentID))
                {
                    //Check the student is eligible or not
                    flag = false;
                    if(currentLoggedInStudent.CheckEligiblity(75.0))
                    {
                        //Check the seat availablity
                        if(department.NumberOfSeats>0)
                        {
                            //Check student already taken any admission
                            int count =0;
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            }
                            if(count==0)
                            {
                                //create admission object
                                AdmissionDetails successfulAdmission = new AdmissionDetails(currentLoggedInStudent.StudentID,department.DepartmentID, DateTime.Now,AdmissionStatus.Admitted);
                                //Reduce seat count
                                department.NumberOfSeats--;
                                //Add to the admission list
                                admissionList.Add(successfulAdmission);
                                //Display admission successful message
                                Console.WriteLine($"You have taken admission successfully. Your admission ID is : {successfulAdmission.AdmissionDate}");
                            }
                            else
                            {
                                Console.WriteLine("You have already taken an admission");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Seats are not available");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("You are not eligible due to low cutoff");
                    }
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID or ID not present");
            }
            
        }// TakeAdmission ends here

        //CancelAdmission starts here
        public static void CancelAdmission()
        {
            //Check whether student is taken any admission and display it
            bool flag = true;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    
                    //Cancel the found admission
                    admission.AdmissionStatus = AdmissionStatus.Cancelled;
                    //Return the seat to department
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            flag = false;
                            break;
                        }
                    }
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("You have no admission to cancel.");
            }
            

        }//CancelAdmission method ends here

        //ShowAdmissionDetails starts here
        public static void ShowAdmissionDetails()
        {
            if(admissionList.Count>0)
            {
                //Need to show current Logged in student's admission details
                Console.WriteLine("|Admission Id|Studennt ID|Department ID|Admission Date|Admission Status|");
                foreach(AdmissionDetails admission in admissionList)
                {
                    if(currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                    {
                        Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate.ToShortDateString()}|{admission.AdmissionStatus}|");
                    }
                }
            }
            else Console.WriteLine("No details found");
            
        }//ShowAdmissionDetails method ends here

        //Department wise seat avaliablity method
        public static void DepartmentWiseSeatAvailablity()
        {
            //Need to show all department details
            Console.WriteLine(line);
            Console.WriteLine("|Department Id|\tDepartment Name|Number of Seats|");
            Console.WriteLine(line);
            foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"|{department.DepartmentID,-13}|{department.DepartmentName,-16}|{department.NumberOfSeats,-15}|");
                Console.WriteLine(line);
            }
        }
        //Adding default data
        public static void AddDefaultData()
        {
            StudentDetails student1 = new StudentDetails("Ravichandran E",	"Ettapparajan", new DateTime(1999,11,11),Gender.Male, 95,95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S",	"Sethurajan",	new DateTime(1999,11,11),	Gender.Male, 95,95, 95	);
            studentList.AddRange(new List<StudentDetails>{student1, student2});

            DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails department3 = new DepartmentDetails("Mech",30);
            DepartmentDetails department4 = new DepartmentDetails("ECE", 30);
            departmentList.AddRange(new List<DepartmentDetails>(){department1,department2,department3,department4});

            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID, "DID101", new DateTime(2022,05,11), AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails(student2.StudentID, department2.DepartmentID, new DateTime(2022,05,12), AdmissionStatus.Admitted);
            admissionList.AddRange(new List<AdmissionDetails>{admission1,admission2});

        
        }

    }
}
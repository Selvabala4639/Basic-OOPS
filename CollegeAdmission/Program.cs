using System;
using System.Collections.Generic;
using System.Security.Cryptography;
namespace CollegeAdmission;

class Program{
    static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
    static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
    
    public static void Main(string[] args)
    {
        int mainMenuOption;
        string addStudent;
        
        //List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        List<StudentDetails> studentList = new List<StudentDetails>();
        StudentDetails stu = new StudentDetails("Ravichandran E", "Ettaparajan", new DateTime(11/11/1999), Enum.Parse<Gender>("Male"),95,95,95);
        studentList.Add(stu);
         stu = new StudentDetails("Baskaran S","Sethurajan", new DateTime(11/11/1999), Enum.Parse<Gender>("Male"),95,95,95);
        studentList.Add(stu);
        //studentList.Add(StudentDetails());
        string departmentId= "DID101";
        string departmentName = "EEE";
        int seats = 29;
        DepartmentDetails department= new DepartmentDetails(departmentId,departmentName,seats);
        departmentList.Add(department);
        departmentId= "DID102";
        departmentName = "CSE";
        seats = 29;
        department= new DepartmentDetails(departmentId,departmentName,seats);
        departmentList.Add(department);
        departmentId= "DID103";
        departmentName = "MECH";
        seats = 30;
        department= new DepartmentDetails(departmentId,departmentName,seats);
        departmentList.Add(department);
        departmentId= "DID104";
        departmentName = "ECE";
        seats = 30;
        department= new DepartmentDetails(departmentId,departmentName,seats);
        departmentList.Add(department);
        AdmissionDetails admi = new AdmissionDetails("SF3001", "DID101",Enum.Parse<Status>("Admitted"));
        admissionList.Add(admi);
        admi = new AdmissionDetails("SF3002", "DID102",Enum.Parse<Status>("Admitted"));
        admissionList.Add(admi);
        departmentList[0].NumberOfSeats--;
        departmentList[1].NumberOfSeats--;
                    
        do{
            MainMenu();
            mainMenuOption= int.Parse(Console.ReadLine());
            switch(mainMenuOption)
            {
                case 1:
                {
                    do{
                    Registration(studentList);
                    Console.Write("Do you want to add new Student: (yes/no)");
                     addStudent= Console.ReadLine();
                    }while(addStudent =="yes");
                    break;
                }
                case 2:
                {
                    Console.Write("Enter your Student ID:");
                    string loginId = Console.ReadLine();
                    foreach(StudentDetails student in studentList)
                    {
                        if(loginId== student.StudentId)
                        {
                            Login(studentList,student);
                        }
                    }
                    break;
                }
                case 3:
                {
                    Console.WriteLine("DepartmentID\t Department Name\t Number of Seats");
                    foreach(DepartmentDetails dept in departmentList)
                    {
                        //Console.WriteLine("DID101\t EEE\t 29");
                        Console.WriteLine($"{dept.DepartmentID}\t\t\t {dept.DepartmentName}\t\t\t {dept.NumberOfSeats}");

                    }
                    break;
                }
                case 4:
                {
                    Console.WriteLine("Application ended.");
                    break;
                }
                default:
                {
                    Console.WriteLine("invalid Option!!!");
                    break;
                }
            }
        }while(mainMenuOption != 4);
    }
    static void MainMenu()
    {
        Console.WriteLine("Syncfusion College of Engineering and Technology");
        Console.WriteLine("1. Student Registration");
        Console.WriteLine("2. Student Login");
        Console.WriteLine("3. Department wise seat availability");
        Console.WriteLine("4. Exit");

    }
    static void Registration(List<StudentDetails> studentList)
    {
        Console.Write("Student Name: ");
        string studentName = Console.ReadLine();
        Console.Write("Father Name: ");
        string fatherName = Console.ReadLine();
        Console.Write("DOB: ");
        

        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy",  null);
        Console.Write("Type as shown below:\n\tMale\n\tFemale\n\tTransgender\nGender: ");
        Gender gender = Enum.Parse<Gender> (Console.ReadLine());
        Console.Write("Physics mark: ");
        int phy = int.Parse(Console.ReadLine());
        Console.Write("Chemistry mark: ");
        int chem = int.Parse(Console.ReadLine());
        Console.Write("Maths mark: ");
        int mat = int.Parse(Console.ReadLine());

        StudentDetails student = new StudentDetails(studentName,fatherName,dob,gender,phy,chem,mat);
        studentList.Add(student);
        Console.WriteLine($"\nStudent Registered Successfully and StudentID is {student.StudentId}");
    }

    static void Login(List<StudentDetails> studentList, StudentDetails student)
    {
        char subMenuOption;
        do{

            Console.WriteLine("\na. Check Eligibility");
            Console.WriteLine("b. Show Details ");
            Console.WriteLine("c. Take Admission");
            Console.WriteLine("d. Cancel Admission");
            Console.WriteLine("e. Show Admission Details");
            Console.WriteLine("f. Exit");
            subMenuOption=char.Parse(Console.ReadLine());
            switch(subMenuOption)
            {
                case 'a':
                {
                    if(student.CheckEligibility())
                    {
                        Console.WriteLine("Student is eligible");
                    }
                    else Console.WriteLine("Student is not eligible");
                    break;
                }
                case 'b':   
                {
                    student.ShowDetails();
                    break;
                }
                case 'c':
                {
                    
                    //List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
                    
                    
                    Console.WriteLine("DepartmentID\t Department Name\t Number of Seats");
                    foreach(DepartmentDetails dept in departmentList)
                    {
                        //Console.WriteLine("DID101\t EEE\t 29");
                        Console.WriteLine($"{dept.DepartmentID}\t\t\t {dept.DepartmentName}\t\t\t {dept.NumberOfSeats}");

                    }
                    Console.Write("Choose one Departrment: ");
                    string chooseDept= Console.ReadLine();
                    bool flag =false;
                    for(int i =0; i<departmentList.Count; i++)
                    {
                        if(chooseDept==departmentList[i].DepartmentID)
                        {
                            Console.WriteLine($"You selected {departmentList[i].DepartmentName}.");
                            if(student.CheckEligibility())
                            {
                                Console.WriteLine("You are eligible to take Admission.");
                                if(departmentList[i].NumberOfSeats>0)
                                {
                                    for(int j=0; j<admissionList.Count; j++)
                                    {
                                        if(admissionList[j].StudentID!=student.StudentId && j==admissionList.Count-1)
                                        {
                                            Status status = Enum.Parse<Status>("Admitted");
                                            AdmissionDetails admission = new AdmissionDetails(student.StudentId, departmentList[i].DepartmentID, status);
                                            admissionList.Add(admission);
                                            departmentList[i].NumberOfSeats--;
                                            Console.WriteLine($"Admission took successfully. Your admission ID - {admission.AdmissionID}");
                                            flag = true;
                                            break;
                                        }
                                        else if(admissionList[j].StudentID==student.StudentId && admissionList[j].AdmissionStatus==Enum.Parse<Status>("Cancelled")) 
                                        {
                                            Status status = Enum.Parse<Status>("Admitted");
                                            AdmissionDetails admission = new AdmissionDetails(student.StudentId, departmentList[i].DepartmentID, status);
                                            admissionList.Add(admission);
                                            departmentList[i].NumberOfSeats--;
                                            Console.WriteLine($"Admission took successfully. Your admission ID - {admission.AdmissionID}");
                                            flag = true;
                                            break;
                                        }
                                        else if(admissionList[j].StudentID==student.StudentId) 
                                        {
                                            Console.WriteLine("You have already taken an admission.");
                                            break;
                                        }

                                    }
                                }
                            }
                            flag = true;
                        } 
                        else if((chooseDept!=departmentList[i].DepartmentID) && (i== (departmentList.Count-1)) && flag==false)
                        {
                            Console.WriteLine("Invalid Department ID!!!");
                            break;
                        }
                    }
                    break;
                }
                case'd':
                {
                    
                    for(int i =0; i<admissionList.Count; i++)
                    {
                        if(student.StudentId==admissionList[i].StudentID)
                        {
                            Console.WriteLine($"Admission Id = {admissionList[i].AdmissionID}");
                            Console.WriteLine($"Student Id = {admissionList[i].StudentID}");
                            Console.WriteLine($"Depatment Id = {admissionList[i].DepartmentID}");
                            Console.WriteLine($"Admission Date = {admissionList[i].AdmissionDate}");
                            Console.WriteLine($"Admission Status = {admissionList[i].AdmissionStatus}");
                            Console.Write("Do you want to Cancel Admission? (yes/no)");
                            string cancelAdmission = Console.ReadLine();
                            if(cancelAdmission=="yes")
                            {
                                admissionList[i].AdmissionStatus = Enum.Parse<Status>("Cancelled");
                                for(int j =0; j<departmentList.Count; j++)
                                {
                                    if(admissionList[i].DepartmentID == departmentList[j].DepartmentID)
                                    {
                                        departmentList[j].NumberOfSeats++;
                                        Console.WriteLine("You're admission has been cancelled");
                                        //admissionList.Remove(admissionList[i]);
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                        else if(student.StudentId!=admissionList[i].StudentID  && i==admissionList.Count-1 )
                        {
                            Console.WriteLine("Still you haven't taken any admission");
                        }
                    }
                    break;
                }
                case 'e':
                {
                    bool flag = false;
                    for(int i =0; i<admissionList.Count; i++)
                    {
                        if(student.StudentId==admissionList[i].StudentID)
                        {
                            Console.WriteLine($"\nAdmission Id = {admissionList[i].AdmissionID}");
                            Console.WriteLine($"Student Id = {admissionList[i].StudentID}");
                            Console.WriteLine($"Depatment Id = {admissionList[i].DepartmentID}");
                            Console.WriteLine($"Admission Date = {admissionList[i].AdmissionDate}");
                            Console.WriteLine($"Admission Status = {admissionList[i].AdmissionStatus}");
                            flag = true;
                        }
                        else if(student.StudentId!=admissionList[i].StudentID  && i==admissionList.Count-1 && flag == false)
                        {
                            Console.WriteLine("Still you haven't taken any admission");
                        }
                    }
                    break;
                }
                case 'f':
                {
                    Console.WriteLine("\nReturned to Main Menu");
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid Sub Menu Option");
                    break;
                }

            }
         }while(subMenuOption!='f');

         
    }
}
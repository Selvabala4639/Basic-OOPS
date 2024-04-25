using System;
using System.Collections.Generic;
namespace CollegeApplication;

class Program{
    public static void Main(string[] args)
    {

        List<StudentDetails> studentList = new List<StudentDetails>();
        string option = "";
        do
        {
           // StudentDetails student1 = new StudentDetails();
            Console.Write("Enter your Name: ");
            string name =Console.ReadLine();

            Console.Write("Enter your Father name: ");
            string fname=Console.ReadLine();

            Console.Write("Enter your Gender: ");
            string gender =Console.ReadLine();

            Console.Write("Enter your DOB: ");
            DateTime dob= DateTime.ParseExact( Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Enter your Phone number: ");
            long phone= long.Parse(Console.ReadLine());

            Console.Write("Enter your Physics mark: ");
            int physics= int.Parse(Console.ReadLine());

            Console.Write("Enter your Maths mark: ");
            int maths= int.Parse(Console.ReadLine());

            Console.Write("Enter your Chemistry mark: ");
            int chem= int.Parse(Console.ReadLine());

            //Parameterized constructor object
            StudentDetails student1 = new StudentDetails( name,  fname,  gender,  dob,  phone,  physics,  maths, chem);

            studentList.Add(student1);
            Console.WriteLine("Do yoy want to continue: yes/no");
            option = Console.ReadLine();
        }while(option=="yes");

        foreach(StudentDetails student in studentList)
        {
            Console.WriteLine($"Name : {student.StudentName}\nFather name: {student.FatherName}");
            Console.WriteLine($"Gender : {student.Gender}\nDOB: {student.DOB}");
            Console.WriteLine($"Phone number : {student.Phone}\nPhysics: {student.Physics}");
            Console.WriteLine($"Maths : {student.Maths}\nChemistry: {student.Chemistry}");

            bool eligibility = student.CheckEligibility(75);
            if(eligibility)
            {
                Console.WriteLine("Eligible");
            }
            else{
                Console.WriteLine("Not Eligible");
            }
            
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeApplication
{
    public class StudentDetails
    {
        //Field  -> contains information
        private string _studentName;
        // Properties
                // public string StudentName
                // {
                //     get
                //     {return _studentName;}
                //     set
                //     {_studentName=value;}
                // }
        public string StudentName { get; set; }
        public string FatherName {get; set;}
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public long Phone { get; set; }
        public int Maths { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        //Events
        //indexers
        //Constructers
        //default Constructor
        public StudentDetails()
        {
            StudentName= "Enter your name";
            FatherName="Enter your father name";
        }

        //Parameterized Constructor
        public  StudentDetails(string studentName,string fatherName, string gender, DateTime dob, long phone, int physics, int maths, int chemistry)
        {
            StudentName=studentName;
            FatherName=fatherName;
            Gender = gender;
            DOB = dob;
            Phone = phone;
            Physics = physics;
            Maths =maths;
            Chemistry = chemistry;
            //return Chemistry;
        }
        //Destructors
        ~StudentDetails()
        {
            Console.WriteLine("Destructor called");
        }

        //Methods -> Behaviors of objects
        public bool CheckEligibility(double cutOff)
        {
            double average = (Physics+ Chemistry +Maths)/3;
            if(average >=cutOff) return true;
            else return false; 
        }


    }
}
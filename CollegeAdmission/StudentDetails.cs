using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Datatype Gender used to select a instance of <see cref="StudentDetails"/> Gender information 
/// 
/// </summary>
public enum Gender{Select, Male, Female, Transgender}
namespace CollegeAdmission
{
    /// <summary>
    /// This class is used to create student details.
    /// Refer documentation on <see href="www.syncfusion.com"/> 
    /// </summary> <summary>
    /// 
    /// </summary>
    public class StudentDetails
    {
        


        /// <summary>
        /// Static field s_studentID used to autoincrement StudentID of the instance of <see cref="StudentDetails"/> 
        /// </summary> <summary>
        /// 
        /// </summary>
        private static int s_studentId = 3000;
        // Auto Property
        // type prop and Press "tab" key
        /// <summary>
        /// StudentID property used to hold a Student's ID of Instaince of <see cref="StudentDetails"
        /// </summary>
        public string StudentId { get; }
        /// <summary>
        /// StudentName property used to hold StudentName of a instance of <see cref="SstudentDetails"
        /// </summary> 
        public string StudentName { get; set; }
        /// <summary>
        /// FatherName property used to hold FatherName of a instance of <see cref="SstudentDetails"
        /// </summary> 
        public string FatherName { get; set; }
        /// <summary>
        /// DOB property used to hold date of birth of a instance of <see cref="SstudentDetails"
        /// </summary> 
        public DateTime DOB { get; set; }
        /// <summary>
        /// Gender property used to hold Gender of a instance of <see cref="SstudentDetails"
        /// </summary> 
        public Gender Gender { get; set; }
        /// <summary>
        /// Physics property used to hold physics mark of a instance of <see cref="SstudentDetails"
        /// </summary> 
        public int Physics { get; set; }
        /// <summary>
        /// Chemistry property used to hold chemisrty mark of a instance of <see cref="SstudentDetails"
        /// </summary> 
        public int Chemistry { get; set; }
        /// <summary>
        /// Maths property used to hold maths mark of a instance of <see cref="SstudentDetails"
        /// </summary> 
        public int Maths { get; set; }

        /// <summary>
        /// Default constructor StudentDetails used to initialize default values to its property.
        /// </summary> <summary>
        public StudentDetails()
        {
            StudentId="SF3001";
            StudentName = "Ravichandran E";
            FatherName = "Ettapparajan";
            DOB = new DateTime(1999,1,1);
            Gender= Gender.Male;
            Physics = 95;
            Chemistry= 95;
            Maths= 95;
        }
        /// <summary>
        /// This parameterized constructor used to get values from the user and  store it in the property.
        /// </summary>
        /// <param name="studentName"> studentName parameter used to assign its value to associated porperty (StudentName)</param>
        /// <param name="fatherName">fatherName parameter used to assign its value to associated porperty (FatherName)</param>
        /// <param name="dob">dob parameter used to assign its value to associated porperty (DOB)</param>
        /// <param name="gender">gender parameter used to assign its value to associated porperty (Gender)</param>
        /// <param name="phy">phy parameter used to assign its value to associated porperty (Physics)</param>
        /// <param name="chem">chem parameter used to assign its value to associated porperty (Chemisrty)</param>
        /// <param name="mat">mat parameter used to assign its value to associated porperty (Maths)</param> <summary>
        /// 
        /// </summary>

        public StudentDetails(string studentName,string fatherName,DateTime dob, Gender gender,int phy ,int chem,int mat)
        {
            s_studentId++;
            StudentId="SF" + s_studentId;
            StudentName = studentName;
            FatherName = fatherName;
            DOB = dob;
            Gender= gender;
            Physics = phy;
            Chemistry= chem;
            Maths= mat;
        }
        /// <summary>
        /// CheckEligibility method is used to check the average of 3 marks of the student to check whether he is eligible to take admission or not.
        /// </summary>
        /// <returns></returns> 
        /// <returns>It returns true or false </returns>
        public  bool CheckEligibility()
        {
            double average = (Physics+ Chemistry+ Maths)/3;
            if(average>=75.0)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// ShowDetails used to display student details to the console.
        /// </summary> <summary>
        /// 
        /// </summary>
        public void ShowDetails()
        {
            Console.WriteLine($"Student Id: {StudentId}");
            Console.WriteLine($"Student Name: {StudentName}");
            Console.WriteLine($"Student's Father name: {FatherName}");
            Console.WriteLine($"Student's DOB: {DOB}");
            Console.WriteLine($"Student's Gender: {Gender}");
            Console.WriteLine($"Physics Mark: {Physics}");
            Console.WriteLine($"Chemistry Mark: {Chemistry}");
            Console.WriteLine($"Maths mark: {Maths}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace StudentAdmission
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("StudentAdmission"))
            {
                Directory.CreateDirectory("StudentAdmission");
                Console.WriteLine($"Folder Created");
            }

            //File for Student Info
            if(!File.Exists("StudentAdmission/StudentDetails.csv"))
            {
                File.Create("StudentAdmission/StudentDetails.csv").Close();
                Console.WriteLine($"StudentDetails.csv file Created");
            }

             //File for Department
             if(!File.Exists("StudentAdmission/DepartmentDetails.csv"))
            {
                File.Create("StudentAdmission/DepartmentDetails.csv").Close();
                Console.WriteLine($"DepartmentDetails.csv file Created");
            }

            //File for admission
             if(!File.Exists("StudentAdmission/AdmissionDetails.csv"))
            {
                File.Create("StudentAdmission/AdmissionDetails.csv").Close();
                Console.WriteLine($"AdmissionDetails.csv file Created");
            }
        }
        public static void WriteToCSV()
            {
                //Student Info
                 string [] students = new string[Operations.studentList.Count];
                 for(int i = 0; i<Operations.studentList.Count; i++)
                 {
                    students[i] = Operations.studentList[i].StudentID+","+Operations.studentList[i].StudentName+","+Operations.studentList[i].FatherName+","+ Operations.studentList[i].DOB.ToString("dd/MM/yyyy")+","+ Operations.studentList[i].Gender+","+ Operations.studentList[i].PhysicsMark+","+ Operations.studentList[i].ChemistryMark+","+ Operations.studentList[i].MathsMark;
                 }
                 File.WriteAllLines("StudentAdmission/StudentDetails.csv",students); 


                 //DepartmentInfo
                 string [] departments = new string[Operations.departmentList.Count];
                 for(int i =0; i<Operations.departmentList.Count; i++)
                 {
                    departments[i] = Operations.departmentList[i].DepartmentID+","+Operations.departmentList[i].DepartmentName+","+Operations.departmentList[i].NumberOfSeats;
                 }
                 File.WriteAllLines("StudentAdmission/DepartmentDetails.csv",departments);

                 //Admission info
                 string[] admissions = new string[Operations.admissionList.Count];
                 for(int i = 0; i<Operations.admissionList.Count; i++)
                 {
                    admissions[i] = Operations.admissionList[i].AdmissionID+","+Operations.admissionList[i].StudentID+","+Operations.admissionList[i].DepartmentID+","+Operations.admissionList[i].AdmissionDate.ToString("dd/MM/yyyy")+","+Operations.admissionList[i].AdmissionStatus;
                 }
                 File.WriteAllLines("StudentAdmission/AdmissionDetails.csv",admissions);
            }

        public static void ReadFromCSV()
        {
            string [] students = File.ReadAllLines("StudentAdmission/StudentDetails.csv");
            foreach(string student in students)
            {
                StudentDetails student1 = new StudentDetails( student);
                Operations.studentList.Add(student1);
            }

            //Department details
            string[] departments = File.ReadAllLines("StudentAdmission/DepartmentDetails.csv");
            foreach(string department in departments)
            {
                DepartmentDetails department1 = new DepartmentDetails(department);
                Operations.departmentList.Add(department1);
            }

            //Admission Details
            string [] admissions = File.ReadAllLines("StudentAdmission/AdmissionDetails.csv");
            foreach(string admission in admissions)
            {
                AdmissionDetails admission1 = new AdmissionDetails(admission);
                Operations.admissionList.Add(admission1);
            }
        }
    }
}
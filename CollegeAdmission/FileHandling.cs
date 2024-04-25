using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace CollegeAdmission
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("CollegeAdmission"))
            {
                Directory.CreateDirectory("CollegeAdmission");
                Console.WriteLine($"Folder Created");
            }

            //File for Student Info
            if(!File.Exists("CollegeAdmission/StudentInfo.csv"))
            {
                File.Create("CollegeAdmission/StudentInfo.csv");
                Console.WriteLine($"StudentInfo.csv file Created");
            }

             //File for Department
             if(!File.Exists("CollegeAdmission/DeaprtmentInfo.csv"))
            {
                File.Create("CollegeAdmission/DeaprtmentInfo.csv");
                Console.WriteLine($"DeaprtmentInfo.csv file Created");
            }

            //File for admission
             if(!File.Exists("CollegeAdmission/AdmissionInfo.csv"))
            {
                File.Create("CollegeAdmission/AdmissionInfo.csv");
                Console.WriteLine($"AdmissionInfo.csv file Created");
            }
        }
    }
}
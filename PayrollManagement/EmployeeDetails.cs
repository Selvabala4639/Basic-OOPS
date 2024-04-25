using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public enum Branch{Select, Eymard, Karuna, Mathura}

public enum Team{Select, Network, Hardware, Developer, Facility}

public enum Gender{Select,Male,Female}
namespace PayrollManagement
{
    public class EmployeeDetails
    {
        private static int s_employeeID=3000;
        public string EmployeeID { get;  }
        public string EmployeeName { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public Branch BranchName { get; set; }
        public Team TeamName { get; set; }

        public EmployeeDetails(string name, DateTime dob, string phn, Gender gender, Branch branchName, Team teamName)
        {
            s_employeeID++;
            EmployeeID = "SF"+ s_employeeID;
            EmployeeName= name;
            DOB = dob;
            Gender = gender;
            BranchName= branchName;
            TeamName= teamName;
        }
        public void ShowEmployeeDetails()
        {
            Console.WriteLine($"EmployeeID: {EmployeeID}");
            Console.WriteLine($"EmployeeName: {EmployeeName}");
            Console.WriteLine($"DOB: {DOB}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"BranchName: {BranchName}");
            Console.WriteLine($"TeamName: {TeamName}");
        }
    }
}
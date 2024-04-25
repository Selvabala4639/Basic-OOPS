using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum Location{Select, Chennai, Bengaluru}
public enum Gender{Select, Male, Female}
namespace EmployeePayrollManagement
{
    public class EmployeeDetails
    {
        private static int s_employeeID=1000;
        public string  EmployeeID { get; }

        public string EmployeeName { get; set; }

        public string EmployeeRole { get; set; }

        public Location EmployeeLocation { get; set; }

        public string TeamName { get; set; }

        public DateTime DOJ { get; set; }

        public int WorkDays { get; set; }

        public int LeaveTaken { get; set; }

        public Gender Gender { get; set; }

        public int Salary { get; set; }

        public EmployeeDetails(string name, string role, Location location, string team, DateTime doj, int workdays, int leaveTaken, Gender gender)
        {
            s_employeeID++;
            EmployeeID = "SF" + s_employeeID;
            EmployeeName= name;
            EmployeeRole= role;
            EmployeeLocation= location;
            TeamName=team;
            DOJ = doj;
            WorkDays = workdays;
            LeaveTaken = leaveTaken;
            Gender = gender;

        }

        public int CalculateSalary()
        {
            Salary=  (WorkDays-LeaveTaken)*500;
            return Salary;
        }
    }


}
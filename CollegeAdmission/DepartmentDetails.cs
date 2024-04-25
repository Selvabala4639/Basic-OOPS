using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class DepartmentDetails
    {
        //private static int s_departmentID=100;
        public string DepartmentID { get; set;}

        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }

        public DepartmentDetails(string id, string name, int seats)
        {
            DepartmentID = id;
            DepartmentName= name;
            NumberOfSeats = seats;
        }
    }
}
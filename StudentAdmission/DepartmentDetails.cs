using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class DepartmentDetails
    {
        /*
        a.	DepartmentID – (AutoIncrement - DID101)
        b.	DepartmentName
        c.	NumberOfSeats
        */
        //Field
        //Static Field
        private static int s_departmentID =100;
        //Properties
        public string DepartmentID { get; }
        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }

        //Constructor
        public DepartmentDetails(string departmentName, int numberOfSeats)
        {
            s_departmentID++;
            DepartmentID= "DID"+s_departmentID;
            DepartmentName = departmentName;
            NumberOfSeats = numberOfSeats;
        }
        public DepartmentDetails(string department)
        {
            string [] values = department.Split(',');

            s_departmentID = int.Parse(values[0].Remove(0,3));
            DepartmentID= values[0];
            DepartmentName = values[1];
            NumberOfSeats = int.Parse(values[2]);
        }
    }
}
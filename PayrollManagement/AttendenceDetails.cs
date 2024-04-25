using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PayrollManagement
{
    public class AttendenceDetails
    {
        private static int s_attendenceId=1000;
        public string AttendenceId { get; }
        public string EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly CheckInTime { get; set; }
        public TimeOnly CheckOutTime { get; set; }
        public int HoursWorked { get; set; }

        public AttendenceDetails(string id, DateTime date, TimeOnly checkin, TimeOnly checkout, int hoursWorked)
        {
            s_attendenceId++;
            AttendenceId = "AID"+s_attendenceId;
            EmployeeID= id;
            Date =date;
            CheckInTime= checkin;
            CheckOutTime= checkout;
            HoursWorked= hoursWorked;
        }
        public  void ShowAttendenceDetails()
        {
            Console.WriteLine($"AttendenceId: {AttendenceId}");
            Console.WriteLine($"EmployeeID: {EmployeeID}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"CheckInTime: {CheckInTime}");
            Console.WriteLine($"CheckOutTime: {CheckOutTime}");
            Console.WriteLine($"HoursWorked: {HoursWorked}");
        }
    }
}
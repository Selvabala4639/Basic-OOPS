using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public enum AdmissionStatus{Select, Admitted, Cancelled}
namespace StudentAdmission
{
    public class AdmissionDetails
    {
        /*
        a.	AdmissionID – (Auto Increment ID - AID1001)
        b.	StudentID
        c.	DepartmentID
        d.	AdmissionDate
        e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)
        */
        //Field
        //Static Field
        private static int s_admissionID =1000;
        //Properties
        public string AdmissionID { get;  }
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus { get; set; }

        //Constructor
        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            s_admissionID++;
            AdmissionID= "AID" + s_admissionID;
            StudentID= studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus= admissionStatus;
        }
        public AdmissionDetails(string admission)
        {
            string [] values = admission.Split(',');

            s_admissionID = int.Parse(values[0].Remove(0,3));
            AdmissionID= values[1];
            StudentID= values[2];
            DepartmentID=values[3];
            AdmissionDate=DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
            AdmissionStatus= Enum.Parse<AdmissionStatus>(values[5]);
        }
    }
}
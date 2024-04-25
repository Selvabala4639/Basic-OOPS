using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// 
/// Enum datatype Status is used to select status of the admission. 
/// </summary> <summary>
/// 
/// </summary>
public enum Status{Select,Admitted,Cancelled}
namespace CollegeAdmission
{
    public class AdmissionDetails
    {
        /// <summary>
        /// static filed s_admissionID is used to autoincrement AdmissionID of the instances of <see cref="StudentDetails"/>
        /// </summary>
        private static int s_admissionID=3000;
        /// <summary>
        /// AdmissionID property used to hold admission's ID of the instances of <see cref="StudentDetails"/>
        /// </summary> 

        public string AdmissionID { get;}
        /// <summary>
        /// StudentID property used to hold student's ID of the instances of <see cref="StudentDetails"/>
        /// </summary> 
        public string StudentID { get; set; }
        /// <summary>
        /// DepartmentID property used to hold department's ID of the instances of <see cref="StudentDetails"/>
        /// </summary> 
        public string DepartmentID { get; set; }
        /// <summary>
        /// AdmissionDate property used to hold admission date of the instances of <see cref="StudentDetails"/>
        /// </summary>
        /// <value></value>
        public DateTime AdmissionDate { get; set; }
        /// <summary>
        /// AdmissionStatus property used to hold status of the instances of <see cref="StudentDetails"/>
        /// </summary> 
        public Status AdmissionStatus { get; set; }

        /// <summary>
        /// Paramertized constructor used to assign get values from the user and  store it in the property.
        /// </summary>
        /// <param name="studentId">studentId parameter used to assign its value to associated porperty (StudentId)</param>
        /// <param name="deptId">deptID parameter used to assign its value to associated porperty (DepartmentID)</param>
        /// <param name="status">status parameter used to assign its value to associated porperty (AdmissionStatus)</param>
        public AdmissionDetails(string studentId, string deptId, Status status)
        {
            s_admissionID++;
            AdmissionID = "AID"+s_admissionID;
            StudentID =studentId;
            DepartmentID = deptId;
            AdmissionDate = DateTime.Today;
            AdmissionStatus= status;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAdmissionApplication

{
    public enum AdmissionStatus{Select,Booked,Cancelled}
    public class AdmissionDetails
    {
        //static field for admission id autogenerated
        private static int s_admisssionID=1000;
        public string AdmissionID { get;  }
        public string StudentID { get;  }

        public string  DepartmentID { get;  }

        public DateTime AdmissionDate{get;}
        public AdmissionStatus AdmissionStatus { get; set; }

        //Parameter constructor for AdmissionDetails class
        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,AdmissionStatus admissionStatus)
        {
            s_admisssionID++;
            AdmissionID="AID"+s_admisssionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        }

        
    }
}
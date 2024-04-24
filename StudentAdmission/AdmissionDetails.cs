using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum AdmissionStatus{Select,Admitted,Cancelled}
    public class AdmissionDetails
    {
                /*Properties:
        a.	AdmissionID – (Auto Increment ID - AID1001)
        b.	StudentID
        c.	DepartmentID
        d.	AdmissionDate
        e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)
        */
        //field
        private static int s_admissionID=1000;
        public string AdmissionID { get; set; }
        public string StudentID { get; set; }//in every class , the property name of class name is only the integer otherwise its string
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus{ get; set; }

        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,AdmissionStatus admissionStatus)
        {
            //auto increment
            s_admissionID++;
            //assigning value
            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;

        }
        public AdmissionDetails(string adms)
        {
            string[] admArray=adms.Split(",");
            //auto increment
            //s_admissionID++;
            //assigning value
            AdmissionID=admArray[0];
            s_admissionID=int.Parse(admArray[0].Remove(0,3));
            StudentID=admArray[1];
            DepartmentID=admArray[2];
            AdmissionDate=DateTime.ParseExact(admArray[3],"dd/MM/yyyy",null);
            AdmissionStatus=Enum.Parse<AdmissionStatus>(admArray[4]);

        }
    }
}
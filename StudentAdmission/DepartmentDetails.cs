using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class DepartmentDetails
    {
        //field
        private static int s_departmentID=100;
        //property
        public string DepartmentID { get; }
        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }
        /*Properties:
        a.	DepartmentID – (AutoIncrement - DID101)
        b.	DepartmentName
        c.	NumberOfSeats
        */
        //Constructor
        public DepartmentDetails(string departmentName,int numberOfSeats)
        {
            //auto increment
            s_departmentID++;
            //assigning value
            DepartmentID="DID"+s_departmentID;
            DepartmentName=departmentName;
            NumberOfSeats=numberOfSeats;

        }
        public DepartmentDetails(string dept)
        {
            string[] deptArray=dept.Split(",");
            //auto increment
            //s_departmentID++;
            //assigning value
            DepartmentID=deptArray[0];
            s_departmentID=int.Parse(deptArray[0].Remove(0,3));
            DepartmentName=deptArray[1];
            NumberOfSeats=int.Parse(deptArray[2]);

        }
    }
}
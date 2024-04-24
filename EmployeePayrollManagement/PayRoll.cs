using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{
     //properties – EmployeeID - (SF1001), Employee name, Role, WorkLocation (enum),
        // Team name, Date of Joining, Number of Working Days in Month, Number of Leave Taken, Gender (enum – Male, Female )
    public enum Gender{Male,Female}
    public enum WorkLocation{chennai,pune,mumbai}
    public class PayRoll
    {
        private static int s_EmployeeId=1000;
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeRoll { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public string TeamName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int NoWorkingDay{get;set;}
        public int NoOfLeaveTaken { get; set; }
        public Gender Gender { get; set; }

        public PayRoll(string emplayeeName,string employeeRoll,string teamNAme,DateTime DOJ, int noOfWorkingDay,int noOfLeaveTaken)
        {
            s_EmployeeId++;
            EmployeeId="SF"+s_EmployeeId;
            EmployeeName=emplayeeName;
            EmployeeRoll=employeeRoll;
            //WorkLocation=workLoc;
            TeamName=teamNAme;
            DateOfJoining=DOJ;
            NoWorkingDay=noOfWorkingDay;
            NoOfLeaveTaken=noOfLeaveTaken;
            //Gender=gender;

        }
        public void CalculateSalary()
        {
            double salary=NoWorkingDay*500;
            Console.WriteLine("Your current month salary is"+salary);

        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRoll
{
    public class AttendanceDetails
    {
                /*Properties:
        •	AttendanceID – AID1001
        •	EmployeeID
        •	Date
        •	CheckInTime
        •	CheckOutTime
        •	HoursWorked
        */
        private static int s_attendanceID=1000;
        public string AttendanceID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly CheckInTime { get; set; }
        public TimeOnly CheckOutTime { get; set; }
        public TimeSpan HoursWorked { get; set; }
        public int Hours { get; set; }
        public int totalAttendance { get;set; }
        public AttendanceDetails(string employeeID,DateTime date,TimeOnly checkIn,TimeOnly checkOut)
        {
            s_attendanceID++;
            AttendanceID="AID"+s_attendanceID;
            EmployeeID=employeeID;
            Date=date;
            CheckInTime=checkIn;
            CheckOutTime=checkOut;
            HoursWorked=checkOut-checkIn;
            Hours=(int)HoursWorked.TotalHours;
            if(Hours>=8)
            {
                totalAttendance++;
            }
        }
        
        public int CheckHoursWorked(TimeOnly checkIn,TimeOnly checkOut)
        {
            CheckInTime=checkIn;
            CheckOutTime=checkOut;
            HoursWorked=checkOut-checkIn;
            Hours=(int)HoursWorked.TotalHours;
            if(Hours>=8)
            {
                Hours=8;
                return Hours;
                totalAttendance=totalAttendance+1;
            
            }
            else{
                Hours=0;
                return Hours;
            }

        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PayRoll
{
    

    public static class Operations
    {
        //List creation
        static List<EmployeeDetails> employeeList=new List<EmployeeDetails>();
        static List<AttendanceDetails> attendanceList=new List<AttendanceDetails>();
        static EmployeeDetails currentEmployee;

        //Main menu
        public static void MainMenu()
        {
            Console.WriteLine("Welcome to Employee payroll management");
            bool flag=true;
            do
            {
                /*1.	Employee Registration
                2.	Employee Login
                3.	Exit*/
                Console.WriteLine("****SELECT ONE****\n 1. Registration\n 2. Login\n 3. Exit");
                int mainMenuChoice=int.Parse(Console.ReadLine());
                switch(mainMenuChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("*****Employee Registration*****");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("*****Employee Login*****");
                        Console.WriteLine("Enter your employe id");
                        string employeeId=Console.ReadLine();
                        foreach(EmployeeDetails employee in employeeList)
                        {
                            if(employeeId==employee.EmployeeID)
                            {
                                //login call
                                currentEmployee=employee;//current employee declaration
                                Login();
                            }
                            else{
                                Console.WriteLine("Your employee id is not present or wrong employee ID !!!");
                            }
                        }
                        
                        break;
                    }
                    case 3:
                    {
                        flag=false;
                        Console.WriteLine("*****Exit from main menu*****");
                        break;
                    }
                }



            }while(flag);
            
        }
        //Main menu ends
        //Login start
        public static void Login()
        {
            /*i.	Add Attendance
            ii.	Display Details
            iii.	Calculate Salary
            iv.	Exit*/
            bool flag=true;
            do{
                Console.WriteLine("-----SELECT ONE-----\n1. Add attendance\n2.Display Details\n3. Calculate salary\n4.Exit");
                int subMenuChoice=int.Parse(Console.ReadLine());
                switch(subMenuChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("***Add attendance****");
                        AddAttendance();

                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("***Display details****");
                        DisplayDetails();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("***Calculate salary****");
                        CalculateSalary();
                        break;
                    }
                    case 4:
                    {
                        flag=false;
                        Console.WriteLine("***Going back to main menu****");
                        break;
                    }
                }


            }while(flag);

            

        }//Login ends
        //Add attendance class starts
        public static void AddAttendance()
        {
            Console.WriteLine("Enter check in date dd/mm/yyyy");
            DateTime date1=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.WriteLine("Enter check in time");
            TimeOnly inTime=TimeOnly.ParseExact(Console.ReadLine(),"HH:mm",null);
            Console.WriteLine("Enter check out time");
            TimeOnly outTime=TimeOnly.ParseExact(Console.ReadLine(),"HH:mm",null);
            AttendanceDetails attendance=new AttendanceDetails(currentEmployee.EmployeeID,date1,inTime,outTime);
            int calAttendance=attendance.CheckHoursWorked(inTime,outTime);
            if(calAttendance>=8)
            {
                attendanceList.Add(attendance);
                Console.WriteLine("Check-in and Checkout Successful and today you have worked 8 Hours");
                //Console.WriteLine("Total attendance"+attendance.totalAttendance);
            }
            else{
                Console.WriteLine("you are not working enough time");
            }

        }//Add attendance ends
        //Display details starts
        public static void DisplayDetails()
        {
            //traverse the employee detail list and show profile infoemation of current employee
                Console.WriteLine($"Employee Id : {currentEmployee.EmployeeID}\nEmployee name:{currentEmployee.FullName}\nEmployee DOB {currentEmployee.DOB}\n MobileNumber : {currentEmployee.MobileNumber}\nGender : {currentEmployee.Gender}\nBranch:{currentEmployee.Branch}\nTeam:{currentEmployee.Team}");

        }//display details ends
        //calculate salary starts
        public static void CalculateSalary()
        {
            int count=0;
            foreach(AttendanceDetails attendance in attendanceList)
            {
                if(currentEmployee.EmployeeID==attendance.EmployeeID)
                {
                    count++;
                    //Console.WriteLine($"attendance ID:{attendance.AttendanceID}\nEmployee Id {attendance.EmployeeID}\ndate : {attendance.Date}\nCheck in time :{attendance.CheckInTime}\nCheck out time : {attendance.CheckOutTime}\n Total hours:{attendance.Hours}");
                }
                //Console.WriteLine($"attendance ID:{attendance.AttendanceID}\nEmployee Id {attendance.EmployeeID}\ndate : {attendance.Date}\nCheck in time :{attendance.CheckInTime}\nCheck out time : {attendance.CheckOutTime}\n Total hours:{attendance.Hours}");
            }
            Console.WriteLine("Your total salary for this month is"+count*500);

        }//calculate salary ends
       


        //Registration method
        public static void Registration()
        {
            /*•	Full Name
            •	DOB
            •	MobileNumber
            •	Gender
            •	Branch 
            •	Team 
            */
            Console.Write("Enter your name : ");
            string name=Console.ReadLine();
            Console.Write("Enter your Date of birth dd/MM/yyyy: ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your Mobile number : ");
            string mobileNumber=Console.ReadLine();
            Console.Write("Enter your Gender : ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your branch -Eymard, Karuna, Madhura: ");
            Branch branch=Enum.Parse<Branch>(Console.ReadLine(),true);
            Console.Write("Enter your team- Network, Hardware, Developer, Facility: ");
            Team team=Enum.Parse<Team>(Console.ReadLine(),true);
            //object creation
            EmployeeDetails employee=new EmployeeDetails(name,dob,mobileNumber,gender,branch,team);
            //adding to list
            employeeList.Add(employee);
            Console.WriteLine("Employee added successfull\n Employee id is : "+employee.EmployeeID);
        }
        //Adding default value
        //Employee details
        public static void AddDefaultData()
        {
            //Employee default data
            EmployeeDetails employee1=new EmployeeDetails("Ravi",new DateTime(1999,11,11),"9958858888",Gender.Male,Branch.Eymard,Team.Developer);
            employeeList.Add(employee1);
            //Attendance default data
            AttendanceDetails attendance1=new AttendanceDetails("SF3001",new DateTime(2022,05,15),new TimeOnly(09,00),new TimeOnly(18,10));
            attendanceList.Add(attendance1);
            AttendanceDetails attendance2=new AttendanceDetails("SF3002",new DateTime(2022,05,16),new TimeOnly(09,10),new TimeOnly(18,50));
            attendanceList.Add(attendance2);
            //printing details
            //foreach(EmployeeDetails employee in employeeList)
            //{
                //Console.WriteLine($"Employee Id : {employee.EmployeeID}\nEmployee name:{employee.FullName}\nEmployee DOB {employee.DOB}\n MobileNumber : {employee.MobileNumber}\nGender : {employee.Gender}\nBranch:{employee.Branch}\nTeam:{employee.Team}");
            //}
            
        }

        
    }
}
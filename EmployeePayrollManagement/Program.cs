using System;
using System.Collections.Generic;
namespace EmployeePayrollManagement;

class Program
{
    public static void Main(string[] args)
    {
        //properties – EmployeeID - (SF1001), Employee name, Role, WorkLocation (enum),
        // Team name, Date of Joining, Number of Working Days in Month, Number of Leave Taken, Gender (enum – Male, Female )
        /*Methods - Salary Calculation
        Execution sequence 
        Design main menu that ask user 1. Registration or 2.Login 3. Exit
        1.	If employee  selected 1. Registration selected ask all property details listed above, create object, display employee ID and store it to list
        2.	If 3. Selected exit from application
        3.	If 2. Login selected ask employee id 
        •	Verify employee id 

        1.	If no match found then tell the “User Invalid ID"
        2.	If match found then display the sub menu 
            1. Calculate salary 2. display details 3. exit
                    a. If 1. Selected calculate salary based on Rs. 500 / One Working day  
                    b. If 2. Selected display the Employee details
                    c. If 3. Pressed exit from submenu and show main menu.*/
        string option = "yes";
        List<PayRoll> PayRollList = new List<PayRoll>();
        do
        {
            Console.WriteLine(":::Welocome to Employee payroll::: \n 1.Registration \n 2.Login \n 3.Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.Write("Enter your name : ");
                        string employeeName = Console.ReadLine();
                        Console.Write("Enter your Role : ");
                        string employeeRole = Console.ReadLine();
                        Console.Write("Enter your Work location : ");
                        Enum workLocation = Enum.Parse<WorkLocation>(Console.ReadLine());
                        Console.Write("Enter your Team name : ");
                        string teamName = Console.ReadLine();
                        Console.Write("Enter your Date of joining : ");
                        DateTime DOJ = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        Console.Write("number of working day in month : ");
                        int workingDay = int.Parse(Console.ReadLine());
                        Console.Write("number of leave taken in month : ");
                        int leaveTaken = int.Parse(Console.ReadLine());
                        Console.Write("Enter your gender : ");
                        Enum gender = Enum.Parse<Gender>(Console.ReadLine(), true);

                        PayRoll obj1 = new PayRoll(employeeName, employeeRole, teamName, DOJ, workingDay, leaveTaken);
                        PayRollList.Add(obj1);
                        Console.WriteLine("Your id is : " + obj1.EmployeeId);

                        Console.WriteLine("Do you want to continue yes/no : ");
                        option = Console.ReadLine();

                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter your EmployeeID : ");
                        string checkId = Console.ReadLine();
                        int inc=0;
                        foreach (PayRoll l1 in PayRollList)
                        {
                            
                            if (checkId == l1.EmployeeId)
                            {
                                inc++;
                                Console.WriteLine("--SELECT ONE-- \n 1.Calculate salary \n 2.Display Details\n 3.Exit");
                                int ch2 = int.Parse(Console.ReadLine());
                                switch (ch2)
                                {
                                    case 1:
                                        {
                                            l1.CalculateSalary();
                                            break;
                                        }
                                    case 2:
                                        {
                                            foreach (PayRoll l2 in PayRollList)
                                            {
                                                Console.WriteLine("-----------------EMPLOYEE DETAILS--------------");
                                                Console.WriteLine($"name:{l2.EmployeeName}\nEmployee roll:{l2.EmployeeRoll}\nworklocation:{l2.WorkLocation}\nTeam name:{l2.TeamName}\nDate of joining:{l2.DateOfJoining}\nNo of working days:{l2.NoWorkingDay}\nNo of leave taken:{l2.NoOfLeaveTaken}\nGender:{l2.Gender}");
                                                
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            break;
                                        }
                                }

                            }//need to change using count
                        
                        }
                        if (inc == 0)
                        {
                            Console.WriteLine("User ID is Invalid!! :-( please try again!!!");

                        }

                        break;
                    }
                case 3:
                    {
                        option = "no";
                        Console.WriteLine("Thank you!");
                        break;
                    }
                default:
                    {
                        option = "no";
                        Console.WriteLine("wrong selection");
                        break;
                    }


            }
            //PayRoll obj1=new PayRoll();


        } while (option == "yes");






    }
}


using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //static class
    public static class Operations//add static. if class is static, inside all method are static
    {
        //Local or Global object creation
        public static StudentDetails currentLoggedInStudent;
        //static customlist creation
        public static CustomList<StudentDetails> studentCustomList = new CustomList<StudentDetails>();
        public static CustomList<DepartmentDetails> departmentCustomList = new CustomList<DepartmentDetails>();
        public static CustomList<AdmissionDetails> admissionCustomList = new CustomList<AdmissionDetails>();
        ////Main menu 
        public static void MainMenu()
        {
            Console.WriteLine("*************WELCOME TO SYNCFUSION COLLEGE*******");

            string mainChoice ="yes";

            do
            {
                //need to show the main menu option
                Console.WriteLine("Main Menu\n1. Registration\n2. Login\n3. Department wise seat availability\n4. Exit");

                //need to get input from user and validate
                Console.Write("select an option : ");

                int mainOption = int.Parse(Console.ReadLine());
                //Need to create mainMenu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("**********Student Registration********");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("***********student Login**************");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("************Departmentwise seat availability**********");
                            DepartmentwiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Application exited successfully");
                            mainChoice = "No";
                            break;
                        }
                }
                //need to iterate until the option exit.
            } while (mainChoice =="yes");

        }//Main menu ends

        //Registration method

        public static void StudentRegistration()
        {
            //neeed to get require details
            // need to create an object
            //need to add in the list
            //need to display confirmation message and ID
            Console.Write("Enter your name: ");
            string name=Console.ReadLine();
            Console.Write("Enter your father name : ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your date of birth dd/MM/yyyy : ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your gender (Male/Female) : ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your physics mark : ");
            int physicsMark=int.Parse(Console.ReadLine());
            Console.Write("Enter your chemistry mark : ");
            int chemMark=int.Parse(Console.ReadLine());
            Console.Write("Enter your maths mark : ");
            int mathsMark=int.Parse(Console.ReadLine());

            //Need to create an o bject
            StudentDetails student=new StudentDetails(name,fatherName,dob,gender,physicsMark,chemMark,mathsMark);
            //add to list
            studentCustomList.Add(student);
            //need to display confirmation message and ID
            Console.WriteLine($"Registration successfull. Student ID: {student.StudentID}");



        }//student registration ends

        //Login method
        public static void StudentLogin()
        {
            //need to get id input
            Console.Write("enter your student ID : ");
            string loginId=Console.ReadLine().ToUpper();
            //validate by its presence in list.
            bool flag=true;
            foreach(StudentDetails student in studentCustomList)
            {
                if(loginId.Equals(student.StudentID))
                {
                    flag=false;
                    //assigning current user to global variable
                    currentLoggedInStudent =student;//need to assign entire object
                    Console.WriteLine("*********Logged in successfully*******");
                    //need to call submenu
                    SubMenu();
                    break;

                }
            }
            //if not-invalid.
            if(flag)
            {
                Console.WriteLine("Invalid Id and Id is not present");

            }

        }//student login ends
        //Submenu
        public static void SubMenu()
        {
            string subChoice="yes";
            do
            {
                //need to show submenu options
                Console.WriteLine("**********SUBMENU************");
                Console.WriteLine("Select an option\n1. check eligibility\n2. show details\n3. Take admission\n4. cancel admission\n5. admission details\n6. Exit");
                //getting user option
                Console.Write("Enter your option : ");
                int subOption=int.Parse(Console.ReadLine());
                //need to create sub menu structure
                switch(subOption)
                {
                    case 1:
                    {
                        Console.WriteLine("*********check eligibility**************");
                        CheckEligibility();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("*********show details****************");
                        ShowDetails();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("*********Taking admission****************");
                        TakeAdmission();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("*********cancel admission****************");
                        CancelAdmission();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("*********admission details****************");
                        AdmissionDetails();
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine("*********Taking back to main menu****************");
                        subChoice="no";
                        break;
                    }
                }
                
                
                //iterate till the option is exit

            }while(subChoice=="yes");

        }//submenu ends
        //check eligibility
        public static void CheckEligibility()
        {
            //Get the cutoff value as input
            Console.WriteLine("Enter the cutoff value");
            double cutoff=double.Parse(Console.ReadLine());
            //check eligible or not
            if(currentLoggedInStudent.CheckEligibility(cutoff))
            {
                Console.WriteLine("student is eligible");
            }
            else
            {
                Console.WriteLine("student is  not eligible");
            }
        

        }
        //check eligibility ends
        //show details starts
        public static void ShowDetails()
        {
            //need to show the current student details
            /*
            foreach (StudentDetails student in studentCustomList)
            {
                if(currentLoggedInStudent.StudentID.Equals(student.StudentID))
                {
                    Console.WriteLine($"|{student.StudentID}|{student.StudentName}|{student.FatherName}|{student.DOB}|{student.Gender}|{student.Physics}|{student.Chemistry}|{student.Maths}|");

                }

            }*/
            Console.WriteLine("|Student ID|Student name|father Name|DOB|Gender|physics mark|chemistry mark|maths mark|");
            Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.Physics}|{currentLoggedInStudent.Chemistry}|{currentLoggedInStudent.Maths}|");

            Console.WriteLine();

        }//show details ends
        //take admission satrts
        public static void TakeAdmission()
        {
            //need to show available department details
            DepartmentwiseSeatAvailability();
            //ask department id from user
            Console.Write("Select an department ID : ");
            string departmentID=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(DepartmentDetails department in departmentCustomList)
            {
                if(departmentID.Equals(department.DepartmentID))
                {
                    flag=false;
                    //check the id is present or not
                    //check the sudent eligible or not
                    if(currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        //check the seat available
                        if(department.NumberOfSeats>0)
                        {
                            int count=0;
                            //check student already taken any admission
                            foreach(AdmissionDetails admission in admissionCustomList)
                            {
                                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;

                                }
                            }
                            if(count==0)
                            {
                                //create admission obj
                                AdmissionDetails admissionTaken=new AdmissionDetails(currentLoggedInStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);
                                //reduce seat count
                                department.NumberOfSeats--;
                                //add to the admission customlist
                                admissionCustomList.Add(admissionTaken);
                                //display admission successfull message
                                Console.WriteLine($"You have taken admission successfully.Admission ID : {admissionTaken.AdmissionID}");

                            }
                            else{
                                Console.WriteLine("You have already taken an admission");
                            }
                            

                        }
                        else
                        {
                            Console.WriteLine("Seats are not available");
                        }
                       

                    }
                    else
                    {
                        Console.WriteLine("you are not eligible due to low cutoff");

                    }
                    
                    break;


                }
            }
            if(flag)
            {
                Console.WriteLine("Invalis id or ID is not present");
            }
            //check the id is present or not
            //check the sudent eligible or not
            //check the seat available
            //check student already taken any admission
            //create admission obj
            //reduce seat count
            //add to the admission customlist
            //display admission successfull message

        }//take admission ends
        //cancel admission starts
        public static void CancelAdmission()
        {
            bool flag=true;
            //check the student whether they taken any admission and display it.
            foreach(AdmissionDetails admission in admissionCustomList)
            {
                if(currentLoggedInStudent.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    //cancel found admission
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    //return the seat to department
                    foreach(DepartmentDetails department in departmentCustomList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            break;
                        }
                    }
                    break;

                }
            }
            if(flag)
            {
                Console.WriteLine("You did not have any admission to cancel");
            }
           

        }//cancel admission ends
        //admisiion details
        public static void AdmissionDetails()
        {
            Console.WriteLine("|Admission id||studentId||Department ID||Admission date||Admission status|");
            //need to show current logged in student admission details
            foreach (AdmissionDetails admission in admissionCustomList)
            {
                if(currentLoggedInStudent.Equals(admission.StudentID))
                {
                    Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}|");

                }
            }

        }//admissiondetails ends

        //Department wise seat availability
        public static void DepartmentwiseSeatAvailability()
        {
            //header
            Console.WriteLine($"Department Id|Department name|Number of sheets");
            //need to show all department details
            foreach (DepartmentDetails department in departmentCustomList)
            {
                Console.WriteLine($"|{department.DepartmentID}|{department.DepartmentName}|{department.NumberOfSeats}|");
            }
            Console.WriteLine();

        }

        //Adding default data
        public static void AddDefaultData()
        {


            //creating object
            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);//remember datetime and enum declaration
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            //adding to a customlist
            //studentCustomList.Add(student1);
            //studentCustomList.Add(student2);  ----or
            studentCustomList.AddRange(new CustomList<StudentDetails>() { student1, student2 });
            //Dapartment Details object
            DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
            DepartmentDetails department4 = new DepartmentDetails("ECE", 30);
            //adding objects to department customlist
            departmentCustomList.AddRange(new CustomList<DepartmentDetails>() { department1, department2, department3, department4 });
            //Admission details object
            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID, department1.DepartmentID, new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails(student2.StudentID, department2.DepartmentID, new DateTime(2022, 05, 12), AdmissionStatus.Admitted);
            //Adding objects to Admission customlist
            admissionCustomList.AddRange(new CustomList<AdmissionDetails>() { admission1, admission2 });

            //printing the data
            
            
            Console.WriteLine();
            



        }
    }
}
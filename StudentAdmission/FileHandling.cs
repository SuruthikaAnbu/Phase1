using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;//mandatory for fileHandling

namespace StudentAdmission
{
    public static class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("StudentAdmission"));//file name and application name should be same
            {
                Console.WriteLine("creating Folder");
                Directory.CreateDirectory("StudentAdmission");//no space, should in pascal case

            }
            // choose customlist created class
            //file for StudentDetails
            if(!File.Exists("StudentAdmission/StudentDetails.csv"))
            {
                Console.WriteLine("creating file...");
                File.Create("StudentAdmission/StudentDetails.csv").Close();
            }
            //File for Department Details
            if(!File.Exists("StudentAdmission/DepartmentDetails.csv"))
            {
                Console.WriteLine("creating file...");
                File.Create("StudentAdmission/DepartmentDetails.csv").Close();
            }
            //File for admissiondetails
            if(!File.Exists("StudentAdmission/AdmissionDetails.csv"))
            {
                Console.WriteLine("creating file...");
                File.Create("StudentAdmission/AdmissionDetails.csv").Close();
            }


        }
        //write in csv file
        //declare customcustomlist as public
        //student info
        public static void WriteToCSV()
        {
            string[] students=new string[Operations.studentCustomList.Count];
            for(int i=0;i<Operations.studentCustomList.Count;i++)
            {
                students[i]=Operations.studentCustomList[i].StudentID+","+Operations.studentCustomList[i].StudentName+","+Operations.studentCustomList[i].FatherName+","+Operations.studentCustomList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.studentCustomList[i].Gender+","+Operations.studentCustomList[i].Physics+","+Operations.studentCustomList[i].Chemistry+","+Operations.studentCustomList[i].Maths;
            }
            File.WriteAllLines("StudentAdmission/StudentDetails.csv",students);
            //department info

            string[] department=new string[Operations.departmentCustomList.Count];
            for(int i=0;i<Operations.departmentCustomList.Count;i++)
            {
                department[i]=Operations.departmentCustomList[i].DepartmentID+","+Operations.departmentCustomList[i].DepartmentName+","+Operations.departmentCustomList[i].NumberOfSeats;
            }
            File.WriteAllLines("StudentAdmission/DepartmentDetails.csv",department);

            //admission info
            string[] admission=new string[Operations.admissionCustomList.Count];
            for(int i=0;i<Operations.admissionCustomList.Count;i++)
            {
                admission[i]=Operations.admissionCustomList[i].AdmissionID+","+Operations.admissionCustomList[i].StudentID+","+Operations.admissionCustomList[i].DepartmentID+","+Operations.admissionCustomList[i].AdmissionDate.ToString("dd/MM/yyyy")+","+Operations.admissionCustomList[i].AdmissionStatus;
            }
             File.WriteAllLines("StudentAdmission/AdmissionDetails.csv",admission);
            
        }
        //read from csv
        public static void ReadFromCSV()
        {
            string[] students=File.ReadAllLines("StudentAdmission/StudentDetails.csv");
            foreach(string student in students)
            {
                StudentDetails student1=new StudentDetails(student);
                Operations.studentCustomList.Add(student1);
            }

            string[] departments=File.ReadAllLines("StudentAdmission/DepartmentDetails.csv");
            foreach(string dept in departments)
            {
                DepartmentDetails dept1=new DepartmentDetails( dept);
                Operations.departmentCustomList.Add(dept1);
            }

            string[] admission=File.ReadAllLines("StudentAdmission/AdmissionDetails.csv");
            foreach(string adm in admission)
            {
                AdmissionDetails admission1=new AdmissionDetails(adm);
                Operations.admissionCustomList.Add(admission1);
            }

        }    
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum Gender { Male, Female, Transgender }
    public class StudentDetails
    {
        //field
        //static field
        private static int s_studentID = 3000;

        //property
        public string StudentID { get; }//read only
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }
                /*
                Properties: 
        a.	StudentID – (AutoGeneration ID – SF3000)
        b.	StudentName
        c.	FatherName
        d.	DOB
        e.	Gender – Enum (Male, Female, Transgender)
        f.	Physics
        g.	Chemistry
        h.	Maths
        */

        //---constructor
        public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender,int physics,int chemistry,int maths)
        {
            //Auto incrementation
            s_studentID++;
            StudentID="SF"+s_studentID;
            //spanner symbol-property   , box symbol - element or variable, two box - parameter
            StudentName=studentName;
            FatherName=fatherName;
            DOB=dob;
            Gender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;

        }
         public StudentDetails(string student)
        {
            string[] values=student.Split(",");
            StudentID=values[0];
            s_studentID=int.Parse(values[0].Remove(0,2));//for incrementing id
            //spanner symbol-property   , box symbol - element or variable, two box - parameter
            StudentName=values[1];
            FatherName=values[2];
            DOB=DateTime.ParseExact((values[3]),"dd/MM/yyyy",null);
            Gender=Enum.Parse<Gender>(values[4]);
            Physics=int.Parse(values[5]);
            Chemistry=int.Parse(values[6]);
            Maths=int.Parse(values[7]);

        }

        //Methods
        //Average checking-one method contain the calculation of that method purpose only.
        public double Average()
        {
            int total=Physics+Chemistry+Maths;
            double average=(double)total/3;//int div by int =int 
            return average;
        }
        //Eligibility checking
        public bool CheckEligibility(double cutOff)
        {
            if(Average()>=cutOff)
            {
                return true;
            }
            return false;

            
        }
    }
}
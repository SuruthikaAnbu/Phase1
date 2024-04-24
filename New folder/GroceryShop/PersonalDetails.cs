using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShop
{
    public enum Gender{male,female}
    public class PersonalDetails
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public string MailID { get; set; }
        //constructor
        public PersonalDetails(string name,string fatherName,Gender gender,string mobile,DateTime dOB,string mailID)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            Mobile=mobile;
            DOB=dOB;
            MailID=mailID;
        }
        /*
        public PersonalDetails(string values)
        {
            string[] value=values.Split(",");
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            Mobile=mobile;
            DOB=dOB;
            MailID=mailID;
        }*/
    }
}
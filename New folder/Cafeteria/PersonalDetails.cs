using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public enum Gender{male,female,transgender}
    public class PersonalDetails
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public string Mobile { get; set; }
        public string MailID { get; set; }
        //constructor
        public PersonalDetails(string name,string fatherName,Gender gender,string mobile,string mailId)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            Mobile=mobile;
            MailID=mailId;
        }
    }
}
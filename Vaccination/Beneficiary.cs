using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaccination
{
    public enum Gender{male,female,others} 
    public class Beneficiary
    {
        
    
        private static int s_registrationNumber=1000;
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }

        public Beneficiary(string name,int age,Gender gender,string mobileNumber,string city)
        {
            s_registrationNumber++;
            RegistrationNumber="BID"+s_registrationNumber;
            Name=name;
            Age=age;
            Gender=gender;
            MobileNumber=mobileNumber;
            City=city;
        }
    }
}
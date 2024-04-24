using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public enum Department{ECE,EEE,CSE}
    public enum Gender{Male,Female}
    public class UserDetails
    {
        /*a.	UserID (Auto Increment – SF3000)
        b.	UserName
        c.	Gender
        d.	Department – (Enum – ECE, EEE, CSE)
        e.	MobileNumber
        f.	MailID
        */
        //Property
        private static int s_userID=3000;
        public string UserID { get; set; }
        public string  UserName { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public string MobileNumber { get; set; }
        public string MailID { get; set; }
        public long WalletBalance { get; set; }
        
    
    public UserDetails(string userName,Gender gender,Department department,string mobileNumber,string mailID,long walletBalance)
    {
        s_userID++;
        UserID="SF"+s_userID;
        UserName=userName;
        Gender=gender;
        Department=department;
        MobileNumber=mobileNumber;
        MailID=mailID;
        WalletBalance=walletBalance;

    }
    public void WalletRecharge(long amount)
    {
        WalletBalance+=amount;

    }
    public void DeductBalance(long amount)
    {
        WalletBalance-=amount;
    
    }
    }
}
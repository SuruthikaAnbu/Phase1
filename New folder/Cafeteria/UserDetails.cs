using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Cafeteria
{
    public class UserDetails:PersonalDetails,IBalance
    {
        private static int s_userID=1000;
        public double _balance;
        public string UserID { get; set; }
        public string WorkStationNumber { get; set; }
        //public int Balance { get; set; }
        public double WalletBalance { get{return _balance;} }
        //constructor
        public UserDetails(string name,string fatherName,Gender gender,string mobile,string mailId,string workStationNumber,double walletBalance):base( name, fatherName, gender, mobile, mailId)
        {
            s_userID++;
            UserID="SF"+s_userID;
            WorkStationNumber=workStationNumber;
            _balance=walletBalance;
        }
        public UserDetails(string user)
        {
            string[] values=user.Split(",");
            //s_userID++;
            UserID=values[0];
            s_userID=int.Parse((values[0]).Remove(0,2));
            WorkStationNumber=values[1];
            _balance=double.Parse(values[2]);
            //base.Name=values[0];
        }
        //method
        public void WalletRecharge(double amount)
        {
            _balance=_balance+amount;
        }
        public void DeductAmount(double amount)
        {
            _balance=_balance-amount;
        }
        
    }
}
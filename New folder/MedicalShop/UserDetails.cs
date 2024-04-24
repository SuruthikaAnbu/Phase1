using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MedicalShop
{
    public class UserDetails:PersonalDetails,IWallet
    {
        private static int s_userID=1000;
        public string UserID { get; set; }
        public double _WalletBalance;
        public double WalletBalance { get{return _WalletBalance;} }

        public UserDetails(string name,int age,string city,string phoneNumber,double balance):base(name,age,city,phoneNumber)
        {
            s_userID++;
            UserID="UID"+s_userID;
            base.Name=name;
            base.Age=age;
            base.City=city;
            base.PhoneNumber=phoneNumber;
            _WalletBalance=balance;
        }
        public UserDetails(string values):base("name",0,"nagai","789989")
        {
            string[] value=values.Split(",");
            s_userID=int.Parse(value[0].Remove(0,3));
            UserID=value[0];
            base.Name=value[1];
            base.Age=int.Parse(value[2]);
            base.City=value[3];
            base.PhoneNumber=value[4];
            _WalletBalance=double.Parse(value[5]);
        }
        public void WalletRecharge(double money)
        {
            _WalletBalance+=money;
        }
        public void DeductBalance(double money)
        {
            _WalletBalance-=money;
        }

    }
}
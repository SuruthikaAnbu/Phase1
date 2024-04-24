using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace GroceryShop
{
    public class CustomerRegistration:PersonalDetails,IBalance
    {
        private static int s_customerID=1000;
        public string CustomerID { get; set; }
        public double WalletBalance { get; set; }
        //constructor
        
        public CustomerRegistration(string name,string fatherName,Gender gender,string mobile,DateTime dOB,string mailID,double walletBalance):base(name,fatherName,gender,mobile,dOB,mailID)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            WalletBalance=walletBalance;
        }
        public CustomerRegistration(string values):base("name","fatherName",Gender.male,"mobile",DateTime.Now,"mailID")
        {
            string[] value=values.Split(",");
            CustomerID=value[0];
            s_customerID=int.Parse(value[0].Remove(0,3));
            Name=value[1];
            FatherName=value[2];
            Gender=Enum.Parse<Gender>(value[3]);
            //Mobile=value[4];
            DOB=DateTime.ParseExact(value[4],"dd/MM/yyyy",null);
            MailID=value[5];
            WalletBalance=double.Parse(value[6]);
        }
        
        public void WalletRecharge(double amount)
        {
            WalletBalance+=amount;
        }
    }
}
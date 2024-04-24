using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserDetails:PersonalDetails,IBalance
    {
        private static int s_cardNumber=1000;
        public string CardNumber { get; set; }
        public double Balance { get; set; }

        //constructor
        public UserDetails(string userName,string phoneNumber,double balance):base(userName,phoneNumber)
        {
            s_cardNumber++;
            CardNumber="CMRL"+s_cardNumber;
            
            base.UserName=userName;
            base.PhoneNumber=phoneNumber;
            Balance=balance;
        }
        public UserDetails(string value):base("userName","phoneNumber")
        {
            string[] values=value.Split(",");
            CardNumber=values[0];
            s_cardNumber=int.Parse(values[0].Remove(0,4));
            
            base.UserName=values[1];
            base.PhoneNumber=values[2];
            Balance=double.Parse(values[3]);
        }

        

        //methods
        public void WalletRecharge(double amount)
        {
            Balance+=amount;
        }
        public void DeductBalance(double amount)
        {
            Balance-=amount;
        }
        
    }
}
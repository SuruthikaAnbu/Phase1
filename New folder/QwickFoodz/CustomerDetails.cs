using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class CustomerDetails:PersonalDetails,IBalance
    {
        private double  _balance;
        private static int s_customerID=1000;
        //property
        public string CustomerID { get; set; }
        public double WalletBalance { get{return _balance;}}

        //constructor
        public CustomerDetails(double balance,string name,string fatherName,Gender gender,string mobile,DateTime dOB,string mailID,string location):base(name,fatherName,gender,mobile,dOB,mailID,location)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            _balance=balance;
            base.Name=name;
            base.FatherName=fatherName;
            base.Gender=gender;
            base.Mobile=mobile;
            base.DOB=dOB;
            base.MailID=mailID;
            base.Location=location;
        }

        //method
        public void WalletRecharge(double money)
        {
            
            _balance+=money;
        }
        public void DeductBalance(double money)
        {
            _balance-=money;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class CustomerDetails
    {
                /*Properties: 
        •	CustomerID (Auto Increment -CID1000)
        •	Name
        •	City
        •	MobileNumber
        •	WalletBalance
        •	EmailID
        */
        private static int s_customerID=1000;
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string MobileNumber { get; set; }
        public long WalletBalance { get; set; }
        public string EmailID { get; set; }

        //constructor
        public CustomerDetails(string name,string city,string mobileNumber,long walletBalance,string emailId)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            Name=name;
            City=city;
            MobileNumber=mobileNumber;
            WalletBalance=walletBalance;
            EmailID=emailId;
        }
        //methods
        /*•	WalletRecharge: Get the recharge amount through parameters and update wallet balance.
     	Deduct Balance: Get the deducted amount through parameters and update wallet balance.*/
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
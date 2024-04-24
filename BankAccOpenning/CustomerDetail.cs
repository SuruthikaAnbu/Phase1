using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccOpenning
{
    public enum Gender{value,Male,Female}
    public class CustomerDetail
    {
        private static int s_CustomerId=1001;
        public string CustomerId{get;}
        public string CustomerName{ get; set; }
        public double Balance{ get; set; }
        public Gender Gender{ get; set; }
        public long Phone { get; set; }
        public string MailId { get; set; }
        public DateTime DOB { get; set; }
        
        public CustomerDetail()
        {
            //CustomerId="Enter your id";
            s_CustomerId++;
            CustomerId="HDFC"+s_CustomerId;
            CustomerName="Enter your name";
        }
        public void Deposite(double money)
        {
            Balance+=money;
        }
        public double Withdraw(double money)
        {
            Balance-=money;
            if(money>Balance)
            {
                return 0;

            }
            else{
                return Balance;
            }
        }
        public static void Learn()
        {
            Console.WriteLine("study sttaic");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbBillCalculation
{
    public class EbBill
    {
        public static int s_meterId=1000;
        public static int s_billId=33;
        public string MeterId { get;set;}
        public string UserName { get; set; }
        public double PhoneNumber { get; set; }
        public string MailID { get; set; }
        public int UnitsUSed { get; set; }

        public EbBill()
        {
            s_meterId++;
            MeterId="EB"+s_meterId;
        }



        public void UnitDeatils()
        {
            s_billId++;
            Console.WriteLine("Bill Id is : "+MeterId+"-"+s_billId);
            Console.WriteLine("user name : "+UserName);
            Console.WriteLine("Total unit used : "+UnitsUSed);
            Console.WriteLine("Your total amount : "+UnitsUSed*5);
        }

        
    }
}
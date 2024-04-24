using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShop
{
    public enum OrderStatus{purchased,cancelled}
    public class OrderDetails
    {
        private static int s_orderID=2000;
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public string MedicineID { get; set; }
        public int MedicineCount { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderDetails(string userID,string medicineID,int medicineCount,double totalPrice,DateTime orderDate,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID="OID"+s_orderID ;
            UserID=userID;
            MedicineID=medicineID;
            MedicineCount=medicineCount;
            TotalPrice=totalPrice;
            OrderDate=orderDate;
            OrderStatus=orderStatus;

        }
        public OrderDetails(string values)
        {
            string[] value=values.Split(",");
            s_orderID=int.Parse(value[0].Remove(0,3));
            OrderID=value[0];
            UserID=value[1];
            MedicineID=value[2];
            MedicineCount=int.Parse(value[3]);
            TotalPrice=double.Parse(value[4]);
            OrderDate=DateTime.ParseExact(value[5],"dd/MM/yyyy",null);
            OrderStatus=Enum.Parse<OrderStatus>(value[6]);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public enum OrderStatus{Initiated,Ordered,Cancelled}
    public class OrderDetails
    {
        private static int s_orderID=1000;
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public OrderDetails(string userId,DateTime orderDate,double totalPrice,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            UserID=userId;
            OrderDate=orderDate;
            TotalPrice=totalPrice;
            OrderStatus=orderStatus;
        }

    }
}
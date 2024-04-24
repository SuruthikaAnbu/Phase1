using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public enum OrderStatus{Initiated, Ordered, Cancelled}
    public class OrdreDetails
    {
       //: OrderID, CustomerID, TotalPrice, DateOfOrder, OrderStatus – {Default, Initiated, Ordered, Cancelled}.
       private static int s_orderID=3000;
       public string OrdreID { get; set; } 
       public string CustomerID { get; set; }
       public double TotalPrice { get; set; }
       public DateTime DateOfOrder { get; set; }
       public OrderStatus OrderStatus { get; set; }

       //constructor
       public OrdreDetails(string customerID,double totalPrice,DateTime dateOfOrder,OrderStatus orderStatus)
       {
            s_orderID++;
            OrdreID="OID"+s_orderID;
            CustomerID=customerID;
            TotalPrice=totalPrice;
            DateOfOrder=dateOfOrder;
            OrderStatus=orderStatus;
       }
    }
}
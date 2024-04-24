using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public enum OrderStatus{Orderd,Cancelled}
    public class OrderDetail
    {
                /*Properties: 
        •	OrderID (Auto Increment – OID1001)
        •	CustomerID
        •	ProductID
        •	TotalPrice 
        •	PurchaseDate
        •	Quantity
        •	OrderStatus – (Enum- Default, Ordered, Cancelled)
        */
        private static int s_orderID=1000;
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public long TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }
        //constructor
        public OrderDetail(string customerID,string productID,long totalPrice,DateTime purchaseDate,int quantity,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=orderStatus;

        }

    }
}
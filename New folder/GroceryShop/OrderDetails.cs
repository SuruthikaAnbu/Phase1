using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShop
{
    public class OrderDetails
    {
        private static int s_orderID=4000;
        public string OrderID { get; set; }
        public string BookingID { get; set; }
        public string ProductID { get; set; }
        public int PurchaseCount { get; set; }
        public double PriceOfOrder { get; set; }

        public OrderDetails(string bookingID,string productID,int purchaseCount,double priceOfOrder)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            BookingID=bookingID;
            ProductID=productID;
            PurchaseCount=purchaseCount;
            PriceOfOrder=priceOfOrder;

        }
        public OrderDetails(string value)
        {
            string[] values=value.Split(",");
            //s_orderID++;
            OrderID=values[0];
            s_orderID=int.Parse(values[0].Remove(0,3));
            BookingID=values[1];
            ProductID=values[2];
            PurchaseCount=int.Parse(values[3]);
            PriceOfOrder=double.Parse(values[4]);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public class CartItem
    {
        private static int s_itemID=100;
        public string ItemID { get; set; }
        public string OrderId { get; set; }
        public string FoodID { get; set; }
        public double OrderPrice { get; set; }
        public int OrderQuantity { get; set; }
        public CartItem(string orderID,string foodID,double orderPrice,int orderQuantity)
        {
            s_itemID++;
            ItemID="ITI"+s_itemID;
            OrderId=orderID;
            FoodID=foodID;
            OrderPrice=orderPrice;
            OrderQuantity=orderQuantity;

        }

    }
}
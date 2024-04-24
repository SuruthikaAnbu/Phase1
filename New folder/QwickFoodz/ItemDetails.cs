using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class ItemDetails
    {
        //: ItemID – (ITID100), OrderID, FoodID, PurchaseCount, PriceOfOrder
        private static int s_itemID=4000;
        public string ItemID { get; set; }
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public int PurchaseCount { get; set; }
        public double PriceOfOrder { get; set; }
        //constructor
        public ItemDetails(string orderID,string foodID,int purchaseCount,double priceOfOrder)
        {
            s_itemID++;
            ItemID="ITID"+s_itemID;
            OrderID=orderID;
            FoodID=foodID;
            PurchaseCount=purchaseCount;
            PriceOfOrder=priceOfOrder;

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShop
{
    public class ProductDetailClass
    {
        private static int s_productID=2000;
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int QuantityAvailable { get; set; }
        public double PricePerQuantity { get; set; }
        //constructor
        public ProductDetailClass(string productName, int quantityAvailable,double pricePerQuantity)
        {
            s_productID++;
            ProductID="SID"+s_productID;
            ProductName=productName;
            QuantityAvailable=quantityAvailable;
            PricePerQuantity=pricePerQuantity;

        }
        public ProductDetailClass(string values)
        {
            string[] value=values.Split(",");
            //s_productID++;
            ProductID=value[0];
            s_productID=int.Parse(value[0].Remove(0,3));
            ProductName=value[1];
            QuantityAvailable=int.Parse(value[2]);
            PricePerQuantity=double.Parse(value[3]);
        }
    }
}
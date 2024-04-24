using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShop
{
    public static class FileHandling
    {
        //create folder
        public static void CreateFolder()
        {
            if(!Directory.Exists("GroceryShop"))
            {
                Console.WriteLine("creating");
                Directory.CreateDirectory("GroceryShop");
            }
            if(!File.Exists("GroceryShop/CustomerRegistration.csv"))//
            {
                Console.WriteLine("creating");
                File.Create("GroceryShop/CustomerRegistration.csv").Close();
            }
            if(!File.Exists("GroceryShop/BookingDetails.csv"))//
            {
                Console.WriteLine("creating");
                File.Create("GroceryShop/BookingDetails.csv").Close();
            }
            if(!File.Exists("GroceryShop/OrderDetails.csv"))//
            {
                Console.WriteLine("creating");
                File.Create("GroceryShop/OrderDetails.csv").Close();
            }
            if(!File.Exists("GroceryShop/PersonalDetails.csv"))
            {
                Console.WriteLine("creating");
                File.Create("GroceryShop/PersonalDetails.csv").Close();
            }
            if(!File.Exists("GroceryShop/ProductDetailClass.csv"))
            {
                Console.WriteLine("creating");
                File.Create("GroceryShop/ProductDetailClass.csv").Close();
            }
            
        }
        //write to CSV
        public static void WriteToCSV()
        {
            string[] cusReg=new string[Opration.customerList.Count];
            for(int i=0;i<Opration.customerList.Count;i++)
            {
                cusReg[i]=Opration.customerList[i].CustomerID+","+Opration.customerList[i].Name+","+Opration.customerList[i].FatherName+","+Opration.customerList[i].Gender+","+Opration.customerList[i].DOB.ToString("dd/MM/yyyy")+","+Opration.customerList[i].MailID+","+Opration.customerList[i].WalletBalance;
            }
            File.WriteAllLines("GroceryShop/CustomerRegistration.csv",cusReg);
            //----------------

            string[] bookDet=new string[Opration.bookingList.Count];
            for(int i=0;i<Opration.bookingList.Count;i++)
            {
                bookDet[i]=Opration.bookingList[i].BookID+","+Opration.bookingList[i].CustomerID+","+Opration.bookingList[i].TotalPrice+","+Opration.bookingList[i].DateOfBooking.ToString("dd/MM/yyyy")+","+Opration.bookingList[i].BookingStatus;
            }
            File.WriteAllLines("GroceryShop/BookingDetails.csv",bookDet);
            //-------------------
            string[] ordDet=new string[Opration.orderList.Count];
            for(int i=0;i<Opration.orderList.Count;i++)
            {
                ordDet[i]=Opration.orderList[i].OrderID+","+Opration.orderList[i].BookingID+","+Opration.orderList[i].ProductID+","+Opration.orderList[i].PurchaseCount+","+Opration.orderList[i].PriceOfOrder;
            }
            File.WriteAllLines("GroceryShop/OrderDetails.csv",ordDet);
            //=================
            string[] perDet=new string[Opration.personalList.Count];
            for(int i=0;i<Opration.personalList.Count;i++)
            {
                perDet[i]=Opration.personalList[i].Name+","+Opration.personalList[i].FatherName+","+Opration.personalList[i].Gender+","+Opration.personalList[i].Mobile+","+Opration.personalList[i].DOB+","+Opration.personalList[i].MailID;
            }
            File.WriteAllLines("GroceryShop/PersonalDetails.csv",perDet);

            string[] proDet=new string[Opration.productList.Count];
            for(int i=0;i<Opration.productList.Count;i++)
            {
                proDet[i]=Opration.productList[i].ProductID+","+Opration.productList[i].ProductName+","+Opration.productList[i].QuantityAvailable+","+Opration.productList[i].PricePerQuantity;
            }
            File.WriteAllLines("GroceryShop/ProductDetailClass.csv",proDet);
        }
        
        //read from CSV
        public static void ReadFromCSV()
        {
            string[] customers=File.ReadAllLines("GroceryShop/CustomerRegistration.csv");
            foreach(string customer in customers)
            {
                CustomerRegistration CR1=new CustomerRegistration(customer);
                Opration.customerList.Add(CR1);
            }
            string[] books=File.ReadAllLines("GroceryShop/BookingDetails.csv");
            foreach(string book in books)
            {
                BookingDetails book1=new BookingDetails(book);
                Opration.bookingList.Add(book1);
            }
            string[] orders=File.ReadAllLines("GroceryShop/OrderDetails.csv");
            foreach(string order in orders)
            {
                OrderDetails orderObj=new OrderDetails(order);
                Opration.orderList.Add(orderObj);
            }
            //personal details
            string[] products=File.ReadAllLines("GroceryShop/ProductDetailClass.csv");
            foreach(string product in products)
            {
                ProductDetailClass proObj=new ProductDetailClass(product);
                Opration.productList.Add(proObj);
            }

        }

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public static class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("Cafeteria"))
            {
                Console.WriteLine("Creating directory...");
                Directory.CreateDirectory("Cafeteria");
            }
            if(!File.Exists("Cafeteria/UserDetails"))
            {
                Console.WriteLine("creat file..");
                File.Create("Cafeteria/UserDetails.csv").Close();//done
            }
            if(!File.Exists("Cafeteria/PersonalDetails"))
            {
                Console.WriteLine("creat file..");
                File.Create("Cafeteria/PersonalDetails.csv").Close();//done
            }
            if(!File.Exists("Cafeteria/FoodDetails"))
            {
                Console.WriteLine("File creating");
                File.Create("Cafeteria/FoodDetails.CSV").Close();//done
            }
            if(!File.Exists("Cafeteria/CartItem"))
            {
                Console.WriteLine("File creating");
                File.Create("Cafeteria/CartItem.CSV").Close();//done
            }
            if(!File.Exists("Cafeteria/OrderDetails"))
            {
                Console.WriteLine("File creating");
                File.Create("Cafeteria/OrderDetails.CSV").Close();//done
            }
        }
        public static void WriteToCSV()
        {
            //userdetails
            string[] user=new string[Operation.userList.Count];
            for(int i=0;i<Operation.userList.Count;i++)
            {
                user[i]=Operation.userList[i].UserID+","+Operation.userList[i].WorkStationNumber+","+Operation.userList[i]._balance;
            }
            File.WriteAllLines("Cafeteria/UserDetails.csv",user);

            //PersonalDetails
            string[] personal=new string[Operation.personalList.Count];
            for(int i=0;i<Operation.personalList.Count;i++)
            {
                personal[i]=Operation.personalList[i].Name+","+Operation.personalList[i].FatherName+","+Operation.personalList[i].Gender+","+Operation.personalList[i].Mobile+","+Operation.personalList[i].MailID;
            }
            File.WriteAllLines("Cafeteria/PersonalDetails.csv",personal);

            //fooddetails
            string[] food=new string[Operation.foodList.Count];
            for(int i=0;i<Operation.foodList.Count;i++)
            {
                food[i]=Operation.foodList[i].FoodID+","+Operation.foodList[i].FoodName+","+Operation.foodList[i].FoodPrice+","+Operation.foodList[i].AvailableQuantity;
            }
            File.WriteAllLines("Cafeteria/FoodDetails.csv",food);

            //cartdetails
            string[] cart=new string[Operation.cartList.Count];
            for(int i=0;i<Operation.cartList.Count;i++)
            {
                cart[i]=Operation.cartList[i].ItemID+","+Operation.cartList[i].OrderId+","+Operation.cartList[i].FoodID+","+Operation.cartList[i].OrderPrice+","+Operation.cartList[i].OrderQuantity;
            }
            File.WriteAllLines("Cafeteria/CartItem.csv",cart);

            //userdetails
            string[] order=new string[Operation.orderList.Count];
            for(int i=0;i<Operation.orderList.Count;i++)
            {
                order[i]=Operation.orderList[i].OrderID+","+Operation.orderList[i].UserID+","+Operation.orderList[i].OrderDate.ToString("dd/MM/yyyy")+","+Operation.orderList[i].TotalPrice+","+Operation.orderList[i].OrderStatus;
            }
            File.WriteAllLines("Cafeteria/OrderDetails.csv",order);

            
        }
        public static void ReadFromCSV()
        {
            string[] users=File.ReadAllLines("Cafeteria/UserDetails.csv");
            foreach(string user in users)
            {
                UserDetails user1=new UserDetails(user);
                Operation.userList.Add(user1);
            }

        }
    }
}
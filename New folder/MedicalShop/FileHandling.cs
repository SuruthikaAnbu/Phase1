using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace MedicalShop
{
    public static class FileHandling
    {
        //create file
        public static void CreateFile()
        {
            if(!Directory.Exists("MedicalShop"))
            {
                Console.WriteLine("creating...");
                Directory.CreateDirectory("MedicalShop");
            }
            //MedicineDetails
            //OrderDetails
            //UserDetails
            if(!File.Exists("MedicalShop/MedicineDetails.csv"))
            {
                Console.WriteLine("creating...");
                File.Create("MedicalShop/MedicineDetails.csv").Close();
            }
            if(!File.Exists("MedicalShop/OrderDetails.csv"))
            {
                Console.WriteLine("creating...");
                File.Create("MedicalShop/OrderDetails.csv").Close();
            }
            if(!File.Exists("MedicalShop/UserDetails.csv"))
            {
                Console.WriteLine("creating...");
                File.Create("MedicalShop/UserDetails.csv").Close();
            }
        }
        //write to file 
        public static void WriteToFile()
        {
            //MedicineDetails
            string[] medicine=new string[Opeartion.medicineList.Count];
            for(int i=0;i<Opeartion.medicineList.Count;i++)
            {
                medicine[i]=Opeartion.medicineList[i].MedicineID+","+Opeartion.medicineList[i].MedicineName+","+Opeartion.medicineList[i].AvailableCount+","+Opeartion.medicineList[i].Price+","+Opeartion.medicineList[i].DateOfExpiry.ToString("dd/MM/yyyy");
            }
            File.AppendAllLines("MedicalShop/MedicineDetails.csv",medicine);  

            //OrderDetails
            string[] order=new string[Opeartion.orderList.Count];
            for(int i=0;i<Opeartion.orderList.Count;i++)
            {
                order[i]=Opeartion.orderList[i].OrderID+","+Opeartion.orderList[i].UserID+","+Opeartion.orderList[i].MedicineID+","+Opeartion.orderList[i].MedicineCount+","+Opeartion.orderList[i].TotalPrice+","+Opeartion.orderList[i].OrderDate.ToString("dd/MM/yyyy")+","+Opeartion.orderList[i].OrderStatus;
            }
            File.AppendAllLines("MedicalShop/OrderDetails.csv",order);
            //UserDetails
            string[] user=new string[Opeartion.userList.Count];
            for(int i=0;i<Opeartion.userList.Count;i++)
            {
                user[i]=Opeartion.userList[i].UserID+","+Opeartion.userList[i].Name+","+Opeartion.userList[i].Age+","+Opeartion.userList[i].City+","+Opeartion.userList[i].PhoneNumber+","+Opeartion.userList[i]._WalletBalance;
            }
            File.AppendAllLines("MedicalShop/UserDetails.csv",user);
            
        }
        //read from file
        
        public static void ReadFromFile()
        {
            //MedicineDetails
            string[] med1=File.ReadAllLines("MedicalShop/MedicineDetails.csv");
            foreach(string med in med1)
            {
                MedicineDetails medObj=new MedicineDetails(med);
                Opeartion.medicineList.Add(medObj);
            }
            //OrderDetails
            string[] ord1=File.ReadAllLines("MedicalShop/OrderDetails.csv");
            foreach(string ord in ord1)
            {
                OrderDetails ordObj=new OrderDetails(ord);
                Opeartion.orderList.Add(ordObj);
            }
            //UserDetails
            string[] user1=File.ReadAllLines("MedicalShop/UserDetails.csv");
            foreach(string user in user1)
            {
                UserDetails userObj=new UserDetails(user);
                Opeartion.userList.Add(userObj);
            }

        }

    }
}
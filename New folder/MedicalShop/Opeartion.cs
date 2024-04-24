using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShop
{
    public static class Opeartion
    {
        public static CustomList<MedicineDetails> medicineList=new CustomList<MedicineDetails>();
        public static CustomList<OrderDetails> orderList=new CustomList<OrderDetails>();
        public static CustomList<PersonalDetails> personalList=new CustomList<PersonalDetails>();
        public static CustomList<UserDetails> userList=new CustomList<UserDetails>();
        static UserDetails currentCustomer;
        //main menu
        public static void MainMenu()
        {
            Console.WriteLine("*********ONLINE MEDICAL STORE**********");
            bool mainFlag=true;
            do{
                Console.WriteLine("---SELECT ONE---\n1.User Registration\n2.UserLogin\n3.Exit");
                int userMainChoice=int.Parse(Console.ReadLine());
                switch(userMainChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("User Registration");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("User Login");
                        Login();
                        break;
                    }
                    case 3:
                    {
                        mainFlag=false;
                        Console.WriteLine("Exit from main menu");
                        break;
                    }
                }

            }while(mainFlag);

        }
        //registration
        public static void Registration()
        {
            Console.Write("Enter your name : ");
            string username=Console.ReadLine();
            Console.Write("Enter your age : ");
            int age=int.Parse(Console.ReadLine());
            Console.Write("Enter your city name : ");
            string city=Console.ReadLine();
            Console.Write("Enter your phone number : ");
            string phone=Console.ReadLine();
            Console.Write("Enter your balance :");
            double balance=double.Parse(Console.ReadLine());
            UserDetails user=new UserDetails(username,age,city,phone,balance);
            userList.Add(user);
            Console.WriteLine("User account is created.your ID is : "+user.UserID);


        }
        //login
        public static void Login()
        {
            Console.WriteLine("Enter the User id : ");
            string CheckUSerID=Console.ReadLine();
            bool flag1=true;
            foreach(UserDetails user in userList)
            {
                if(user.UserID==CheckUSerID)
                {
                    flag1=false;
                    currentCustomer=user;
                    SubMenu();
                }
            }
            if(flag1)
            {
                Console.WriteLine("Invalid user ID");
            }

        }
        //submenu
        public static void SubMenu()
        {
            bool subChoice=true;
            do{
                Console.WriteLine("---SELECT ONE---\n1.show medicine list\n2.purchase mecichine\n3.modify purchase\n4.cancel purchase\n5.show purchase history\n6.recharge wallet\n7.show wallet balance\n8.Exit");
                int userSubChoice=int.Parse(Console.ReadLine());
                switch(userSubChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("show madichile list");
                        ShowMadicineDetail();
                        break;
                    }
                    case 2:
                    {
                        PurchaseMedicine();
                        Console.WriteLine("Purchase medicine");
                        break;
                    }
                    case 3:
                    {
                        ModifyPurchase();
                        Console.WriteLine("Modify purchase");
                        break;
                    }
                    case 4:
                    {
                        CancelPurchase();
                        Console.WriteLine("Cancel purchase");
                        break;
                    }
                    case 5:
                    {
                        ShowPurchaseHistory();
                        Console.WriteLine("Show purchase history");
                        break;
                    }
                    case 6:
                    {
                        RechargeWallet();
                        Console.WriteLine("Recharge Wallet");
                        break;
                    }
                    case 7:
                    {
                        ShowWalletBalance();
                        Console.WriteLine("Show Wallet Balance");
                        break;
                    }
                    case 8:
                    {
                        subChoice=false;
                        Console.WriteLine("Exit from sub menu");
                        break;
                    }
                }

            }while(subChoice);
        }
        //show medicine
        public static void ShowMadicineDetail()
        {
            Console.WriteLine("Medicine ID | Medicine name | available count |price | date of expiry");
            foreach(MedicineDetails medicine in medicineList)
            {
                Console.WriteLine($"{medicine.MedicineID}|{medicine.MedicineName}|{medicine.AvailableCount}|{medicine.Price}|{medicine.DateOfExpiry.ToString("dd/MM/yyyy")}");
            }

        }
        //purchase medicine
        public static void PurchaseMedicine()
        {
            Console.WriteLine("Medicine ID | Medicine name | available count |price | date of expiry");
            foreach(MedicineDetails medicine in medicineList)
            {
                Console.WriteLine($"{medicine.MedicineID}|{medicine.MedicineName}|{medicine.AvailableCount}|{medicine.Price}|{medicine.DateOfExpiry.ToString("dd/MM/yyyy")}");
            }
            Console.WriteLine("Select one Medicine ID");
            string checkMedicineID=Console.ReadLine();
            Console.WriteLine("Enter the number of count");
            int checkMedicineCount=int.Parse(Console.ReadLine());
            bool flag=true;
            foreach(MedicineDetails medicine in medicineList)
            {
                if(medicine.MedicineID==checkMedicineID)
                {
                    flag=false;
                    if(medicine.AvailableCount>=checkMedicineCount)
                    {
                        if(medicine.DateOfExpiry>=DateTime.Now)
                        {
                            double medAmount=medicine.Price*checkMedicineCount;
                            if(currentCustomer._WalletBalance>=medAmount)
                            {
                                currentCustomer._WalletBalance-=medAmount;
                                medicine.AvailableCount-=checkMedicineCount;
                                OrderDetails orderObj=new OrderDetails(currentCustomer.UserID,medicine.MedicineID,checkMedicineCount,medAmount,DateTime.Now,OrderStatus.purchased);
                                orderList.Add(orderObj);
                                Console.WriteLine("medicine was purchased successfully");
                            }
                            else{
                                flag=true;
                                break;
                            }

                        }
                        else{
                            flag=true;
                            break;
                        }
                    }
                    else{
                        flag=true;
                        break;
                    }

                }
            }
            if(flag)
            {
                Console.WriteLine("Wrong medicine ID");
            }

        }
        //modify purchase
        public static void ModifyPurchase()
        {
            Console.WriteLine("OrderID  | UserID  | MedicineID  |MedicineCount | TotalPrice| OrderDate |OrderStatus");
            foreach(OrderDetails order in orderList)
            {
                if(currentCustomer.UserID==order.UserID)
                {
                    Console.WriteLine($"{order.OrderID}|{order.UserID}|{order.MedicineID}|{order.MedicineCount}|{order.TotalPrice}|{order.OrderDate.ToString("dd/MM/yyyy")}|{order.OrderStatus}");
                }
            }
            Console.WriteLine("choose the order ID you want modify...");
            string checkOrderID=Console.ReadLine();
            foreach(OrderDetails order in orderList)
            {
                if(order.OrderID == checkOrderID &&currentCustomer.UserID==order.UserID&&order.OrderStatus==OrderStatus.purchased)
                {
                    Console.WriteLine("Enter the new Quantity of the medicine :");
                    int quanMecichine=int.Parse(Console.ReadLine());
                    foreach(MedicineDetails medicine in medicineList)
                    {
                        if(medicine.MedicineID==order.MedicineID)
                        {
                            double orderPrice=medicine.Price*quanMecichine;
                            order.TotalPrice=orderPrice;
                            order.MedicineCount=quanMecichine;
                            medicine.AvailableCount-=quanMecichine;
                            Console.WriteLine("modified successfully...");
                        }

                    }
                    //double orderPrice=order.TotalPrice*quanMecichine;
                    //order.TotalPrice=orderPrice;
                }
            }

        }
        //cancel purchase
        public static void CancelPurchase()
        {
            ShowPurchaseHistory();
            Console.WriteLine("Enter the order ID : ");
            string checkOrderID=Console.ReadLine();
            foreach(OrderDetails order in orderList)
            {
                if(order.OrderID == checkOrderID &&currentCustomer.UserID==order.UserID&&order.OrderStatus==OrderStatus.purchased)
                {
                    foreach(MedicineDetails medicine in medicineList)
                    {
                        if(medicine.MedicineID==order.MedicineID)
                        {
                            medicine.AvailableCount+=order.MedicineCount;
                            currentCustomer._WalletBalance+=order.TotalPrice;
                            order.OrderStatus=OrderStatus.cancelled;
                            Console.WriteLine(order.OrderID+"Order cancelled successfully");

                        }
                    }

                }
            }

        }
        //show purchase history 
        public static void ShowPurchaseHistory()
        {
            Console.WriteLine("OrderID  | UserID  | MedicineID  |MedicineCount | TotalPrice| OrderDate |OrderStatus");
            foreach(OrderDetails order in orderList)
            {
                if(currentCustomer.UserID==order.UserID)
                {
                    Console.WriteLine($"{order.OrderID}|{order.UserID}|{order.MedicineID}|{order.MedicineCount}|{order.TotalPrice}|{order.OrderDate.ToString("dd/MM/yyyy")}|{order.OrderStatus}");
                }    
            }

        }
        //Recharge wallet
        public static void RechargeWallet()
        {
            Console.WriteLine("Enter the amount to recharge : ");
            double amount=double.Parse(Console.ReadLine());
            currentCustomer.WalletRecharge(amount);
            Console.WriteLine("Recharge successfully. your current balance is"+currentCustomer._WalletBalance);

        }
        //show wallet balance
        public static void ShowWalletBalance()
        {
            Console.WriteLine("your current balance is "+currentCustomer._WalletBalance);
        }

        public static void DefaultData()
        {
            //userDetails
            UserDetails user1=new UserDetails("Ravi",33,"Theni","9877774440",400);
            UserDetails user2=new UserDetails("Baskaran",33,"chennai","8877774440",500);
            userList.Add(user1);
            userList.Add(user2);
            Console.WriteLine("userID | username | age |city | phone | balance");
            foreach(UserDetails user in userList)
            {
                Console.WriteLine($"{user.UserID}|{user.Name}|{user.Age}|{user.City}|{user.PhoneNumber}|{user._WalletBalance}");
            }

            //medicine details
            MedicineDetails medicine1=new MedicineDetails("Paracitamol",40,5,new DateTime(2024,06,30));
            MedicineDetails medicine2=new MedicineDetails("Calpol",10,5,new DateTime(2024,05,30));
            MedicineDetails medicine3=new MedicineDetails("Gelucil",3,40,new DateTime(2024,04,30));
            MedicineDetails medicine4=new MedicineDetails("Metrogel",5,50,new DateTime(2024,12,30));
            MedicineDetails medicine5=new MedicineDetails("Povidin Iodin",10,50,new DateTime(2024,10,30));
            medicineList.AddRange(new CustomList<MedicineDetails>{medicine1,medicine2,medicine3,medicine4,medicine5});
            Console.WriteLine("Medicine ID | Medicine name | available count |price | date of expiry");
            foreach(MedicineDetails medicine in medicineList)
            {
                Console.WriteLine($"{medicine.MedicineID}|{medicine.MedicineName}|{medicine.AvailableCount}|{medicine.Price}|{medicine.DateOfExpiry.ToString("dd/MM/yyyy")}");
            }
            //OrderDetails
            OrderDetails order1=new OrderDetails("UID1001","MD101",3,15,new DateTime(2022,11,13),OrderStatus.purchased);
            OrderDetails order2=new OrderDetails("UID1001","MD102",2,10,new DateTime(2022,11,13),OrderStatus.cancelled);
            OrderDetails order3=new OrderDetails("UID1001","MD104",2,100,new DateTime(2022,11,13),OrderStatus.purchased);
            OrderDetails order4=new OrderDetails("UID1002","MD103",3,120,new DateTime(2022,11,15),OrderStatus.cancelled);
            OrderDetails order5=new OrderDetails("UID1002","MD105",5,250,new DateTime(2022,11,15),OrderStatus.purchased);
            OrderDetails order6=new OrderDetails("UID1002","MD102",3,15,new DateTime(2022,11,15),OrderStatus.purchased);
            orderList.AddRange(new CustomList<OrderDetails>{order1,order2,order3,order4,order5,order6});
            
            Console.WriteLine("OrderID  | UserID  | MedicineID  |MedicineCount | TotalPrice| OrderDate |OrderStatus");
            foreach(OrderDetails order in orderList)
            {
                Console.WriteLine($"{order.OrderID}|{order.UserID}|{order.MedicineID}|{order.MedicineCount}|{order.TotalPrice}|{order.OrderDate.ToString("dd/MM/yyyy")}|{order.OrderStatus}");
                
            }

        }
    }
}
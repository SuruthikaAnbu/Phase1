using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public static class Operation
    {
        public static CustomList<PersonalDetails> personalList = new CustomList<PersonalDetails>();
        public static CustomList<CustomerDetails> customerList = new CustomList<CustomerDetails>();
        public static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
        public static CustomList<OrdreDetails> orderList = new CustomList<OrdreDetails>();
        public static CustomList<ItemDetails> itemList = new CustomList<ItemDetails>();
        static CustomerDetails currentCustomer;
        //mainMenu
        public static void MainMenu()
        {
            bool flag = true;
            do
            {
                Console.WriteLine("Welcome to Qwick foodz\n---SELECT ONE---\n1. Customer Registration\n2.Customer Login\n3.Exit");
                int mainChoice = int.Parse(Console.ReadLine());
                switch (mainChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("****Registration****");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("****Login****");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("****Exit from main menu****");
                            flag = false;
                            break;
                        }
                }
            } while (flag);


        }
        //registration
        public static void Registration()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your father name: ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your gender male/female/transgender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter your mobile : ");
            string mobile = Console.ReadLine();
            Console.Write("Enter your dob: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter your mail ID: ");
            string mailID = Console.ReadLine();
            Console.Write("Enter your location : ");
            string location = Console.ReadLine();
            Console.WriteLine("Enter your balance : ");
            double amount = double.Parse(Console.ReadLine());
            CustomerDetails customer = new CustomerDetails(amount, name, fatherName, gender, mobile, dob, mailID, location);
            Console.WriteLine("Customer registration successfully and your customer id is : " + customer.CustomerID);


        }
        //login
        public static void Login()
        {
            bool flag = true;
            Console.WriteLine("Enter your customer ID :");
            string checkCustomerID = Console.ReadLine();
            foreach (CustomerDetails customer in customerList)
            {
                if (customer.CustomerID == checkCustomerID)
                {
                    flag = false;
                    currentCustomer = customer;
                    SubMenu();
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid user ID  ");
            }


        }
        //submenu
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                Console.WriteLine("---SELECT ONE---\n1.Show profile\n2.Order food\n3.Cancel order\n4.Modify order\n5.order history\n6.Recharge wallet\n7.show wallet balance\n8.Exit from submenu");
                int subChoice = int.Parse(Console.ReadLine());
                switch (subChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("Show profile");
                            ShowProfile();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("order food");
                            OrderFood();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("CancelOrder");
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Modify Oder");
                            ModifyOrder();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Order History");
                            OrderHistory();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Recharge wallet");
                            RechargeWallet();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Show wallet balance");
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("exit from sub menu");
                            flag = false;
                            break;
                        }
                }


            } while (flag);
        }
        //show profile
        public static void ShowProfile()
        {
            Console.WriteLine("CustomerID	WalletBalance	Name	FatherName	Gender	Mobile	DOB	MailID	Location");
            foreach (CustomerDetails customer in customerList)
            {
                if (currentCustomer.CustomerID == customer.CustomerID)
                {
                    Console.WriteLine($"{customer.CustomerID}|{customer.WalletBalance}|{customer.Name}|{customer.FatherName}|{customer.Gender}|{customer.Mobile}|{customer.DOB.ToString("dd/MM/yyyy")}|{customer.MailID}|{customer.Location}");
                }
            }

        }
        //order food
        public static void OrderFood()
        {
            OrdreDetails order1 = new OrdreDetails(currentCustomer.CustomerID, 0, DateTime.Now, OrderStatus.Initiated);
            List<ItemDetails> localItemList = new List<ItemDetails>();
            string userOrderChoice = "YES";
            double totalPrice = 0;
            do
            {
                Console.WriteLine("FoodID	FoodName	PricePerQuantity	QuantityAvailable");
                foreach (FoodDetails food in foodList)
                {
                    Console.WriteLine($"{food.FoodID}|{food.FoodName}|{food.PricePerQuantity}|{food.QuantityAvailable}|");
                }
                Console.Write("Enter the food ID ");
                string checkFoodID = Console.ReadLine();
                Console.Write("Enter the food quantity ");
                int checkFoodQuantity = int.Parse(Console.ReadLine());
                bool flag1 = true;
                bool flag2 = false;

                foreach (FoodDetails food in foodList)
                {
                    //double totalPrice = 0;
                    if (food.FoodID == checkFoodID)
                    {
                        flag1 = false;
                        if (food.QuantityAvailable >= checkFoodQuantity)
                        {
                            //Console.WriteLine("Food");
                            flag2 = true;
                            double orderAmount = food.PricePerQuantity * checkFoodQuantity;
                            ItemDetails item = new ItemDetails(order1.OrdreID, food.FoodID, checkFoodQuantity, orderAmount);
                            food.QuantityAvailable -= checkFoodQuantity;
                            localItemList.Add(item);
                            totalPrice += orderAmount;
                            Console.WriteLine("Amout is" + orderAmount + "total amount" + totalPrice);
                            Console.WriteLine("Do you want to order more yes/no");
                            userOrderChoice = Console.ReadLine().ToUpper();
                        }

                    }

                }
                if (flag1)
                {
                    Console.WriteLine("invalid ID");

                }
                if (!flag2)
                {
                    Console.WriteLine("Quantity not available");

                }

            } while (userOrderChoice == "YES");
            Console.WriteLine("Do you want to confirm the purchase yes / no");
            string purchaseConfirmation = Console.ReadLine().ToUpper();
            if (purchaseConfirmation == "YES")
            {
                string userRechargeChoice="";
                do
                {
                    if (currentCustomer.WalletBalance >= totalPrice)
                    {
                        Console.WriteLine("you have sufficeient balance order placed successfully");
                        order1.TotalPrice = totalPrice;
                        order1.OrderStatus = OrderStatus.Ordered;
                        orderList.Add(order1);
                        currentCustomer.DeductBalance(totalPrice);
                        foreach (ItemDetails item in localItemList)
                        {
                            ItemDetails itemObj = new ItemDetails(item.OrderID, item.FoodID, item.PurchaseCount, item.PriceOfOrder);
                            itemList.Add(itemObj);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You did not have a enough balance.Do you want to recharge now yes/no");
                        userRechargeChoice = Console.ReadLine().ToUpper();
                        if (userRechargeChoice == "YES")
                        {
                            RechargeWallet();

                        }
                        else
                        {
                            userRechargeChoice="no";
                            foreach (ItemDetails items in localItemList)
                            {
                                foreach (FoodDetails foods in foodList)
                                {
                                    if (items.FoodID == foods.FoodID)
                                    {
                                        foods.QuantityAvailable += items.PurchaseCount;
                                        break;
                                    }
                                }
                            }

                        }


                    }

                }while(userRechargeChoice=="YES");
            }
            else
            {
                foreach (ItemDetails items in localItemList)
                {
                    foreach (FoodDetails foods in foodList)
                    {
                        if (items.FoodID == foods.FoodID)
                        {
                            foods.QuantityAvailable += items.PurchaseCount;
                        }
                    }
                }
            }


        }
        //cancel order
        public static void CancelOrder()
        {
            Console.WriteLine("OrderID	CustomerID	TotalPrice	DateOfOrder	OrderStatus");
            foreach (OrdreDetails order in orderList)
            {
                if(currentCustomer.CustomerID==order.CustomerID && order.OrderStatus==OrderStatus.Ordered)
                {
                    Console.WriteLine($"{order.OrdreID}|{order.CustomerID}|{order.TotalPrice}|{order.DateOfOrder}|{order.OrderStatus}|");
                }
            }
            Console.WriteLine("choose the orderID to be cancel");
            string choosenCancelOrderID=Console.ReadLine();
            bool flag=true;
            foreach (OrdreDetails order in orderList)
            {
                if(currentCustomer.CustomerID==order.CustomerID && order.OrderStatus==OrderStatus.Ordered)
                {
                    //Console.WriteLine("1");
                    if(order.OrdreID==choosenCancelOrderID)
                    {
                        //Console.WriteLine("2");
                        order.OrderStatus=OrderStatus.Cancelled;
                        //Console.WriteLine("3");
                        currentCustomer.WalletRecharge(order.TotalPrice);
                        bool flag1=true;
                        foreach(ItemDetails item in itemList)
                        {
                            //Console.WriteLine("33");
                            if(order.OrdreID==item.OrderID)
                            {
                                foreach(FoodDetails foods in foodList)
                                {
                                    if(item.FoodID==foods.FoodID)
                                    {
                                        flag1=false;
                                        flag=false;
                                        foods.QuantityAvailable+=item.PurchaseCount;
                                        Console.WriteLine("order cancelled successfully");
                                        break;
                                    }
                                }
                            }
                            if(!flag1)
                            {
                                break;
                            }
                        
                            
                            
                        }
                        
                        
                    }
                }
                if(!flag)
                {
                    break;
                }
            }

        }
        //modify order
        public static void ModifyOrder()
        {
            Console.WriteLine("OrderID	CustomerID	TotalPrice	DateOfOrder	OrderStatus");
            foreach (OrdreDetails order in orderList)
            {
                if(currentCustomer.CustomerID==order.CustomerID && order.OrderStatus==OrderStatus.Ordered)
                {
                    Console.WriteLine($"{order.OrdreID}|{order.CustomerID}|{order.TotalPrice}|{order.DateOfOrder}|{order.OrderStatus}|");
                }
            }
            Console.WriteLine("enter the order id to modify order :");
            string userOrderId=Console.ReadLine();
            foreach (OrdreDetails order in orderList)
            {
                if(userOrderId==order.OrdreID && currentCustomer.CustomerID==order.CustomerID &&order.OrderStatus==OrderStatus.Ordered)
                {
                    Console.WriteLine("ItemID	OrderID	FoodID	PurchaseCount	PriceOfOrder");
                    foreach(ItemDetails item in itemList)
                    {
                        if(order.OrdreID==item.OrderID)
                        {
                            Console.WriteLine($"{item.ItemID}|{item.OrderID}|{item.FoodID}|{item.PurchaseCount}|{item.PriceOfOrder}");

                        }
                    }
                        //if(order.OrdreID==item.OrderID)
                        {
                            //Console.WriteLine($"{item.ItemID}|{item.OrderID}|{item.FoodID}|{item.PurchaseCount}|{item.PriceOfOrder}");
                            Console.WriteLine("choose one item ID to modify");
                            string choosenItemID=Console.ReadLine();
                            foreach(ItemDetails itemss in itemList)
                            {
                                //Console.WriteLine($"{item.ItemID}|{item.OrderID}|{item.FoodID}|{item.PurchaseCount}|{item.PriceOfOrder}");
                                if(itemss.ItemID==choosenItemID)
                                {
                                    Console.WriteLine("Enter the new quantity of item");
                                    int newQuan=int.Parse(Console.ReadLine());
                                    
                                    double amount=0;
                                    foreach(FoodDetails food in foodList)
                                    {
                                        if(food.FoodID==itemss.FoodID)
                                        {
                                            amount=food.PricePerQuantity*newQuan;
                                            if(itemss.PurchaseCount<newQuan)
                                            {
                                                double collectedAmount=(newQuan-itemss.PurchaseCount)*food.PricePerQuantity;
                                                if(currentCustomer.WalletBalance>=collectedAmount)
                                                {
                                                    currentCustomer.DeductBalance(collectedAmount);
                                                }
                                                else{
                                                    Console.WriteLine("you have insufficient balance");
                                                    RechargeWallet();
                                                }
                                            }
                                            itemss.PurchaseCount=newQuan;
                                            itemss.PriceOfOrder=amount;
                                            Console.WriteLine(itemss.OrderID+"order ID modified successfully");
                                            break;
                                        }
                                    }
                                    //double amount=itemss.
                                }
                            }


                        }
                    //}


                }
            }

        }
        //order history
        public static void OrderHistory()
        {
            Console.WriteLine("OrderID	CustomerID	TotalPrice	DateOfOrder	OrderStatus");
            foreach (OrdreDetails order in orderList)
            {
                if (currentCustomer.CustomerID == order.CustomerID)
                {
                    Console.WriteLine($"{order.OrdreID}|{order.CustomerID}|{order.TotalPrice}|{order.DateOfOrder}|{order.OrderStatus}|");
                }
            }

        }
        //Recharge wallet
        public static void RechargeWallet()
        {
            Console.WriteLine("Enter the amount to recharge : ");
            double amount = double.Parse(Console.ReadLine());
            currentCustomer.WalletRecharge(amount);
            Console.WriteLine("Recharge successfully. your current balance is : " + currentCustomer.WalletBalance);

        }
        //show wallet balance
        public static void ShowWalletBalance()
        {
            Console.WriteLine("Your current wallet balance is " + currentCustomer.WalletBalance);
        }
        public static void AddDefaultData()
        {
            CustomerDetails customer1 = new CustomerDetails(10000, "Ravi", "Ettapparajan", Gender.Male, "974774646", new DateTime(1999, 11, 11), "ravi@gmail.com", "Chennai");
            CustomerDetails customer2 = new CustomerDetails(15000, "Baskaran", "Srthurajan", Gender.Male, "847575775", new DateTime(1999, 11, 11), "baskaran@gmail.com", "Chennai");
            customerList.Add(customer1);
            customerList.Add(customer2);
            //Console.WriteLine("CustomerID	WalletBalance	Name	FatherName	Gender	Mobile	DOB	MailID	Location");
            
            //food details
            FoodDetails food1 = new FoodDetails("Chicken Briyani 1Kg", 100, 12);
            FoodDetails food2 = new FoodDetails("Mutton  Briyani 1Kg", 150, 10);
            FoodDetails food3 = new FoodDetails("Veg Full Meals", 80, 30);
            FoodDetails food4 = new FoodDetails("Noodles", 100, 40);
            FoodDetails food5 = new FoodDetails("Dosa", 40, 40);
            FoodDetails food6 = new FoodDetails("Idly (2 pieces)", 20, 50);
            FoodDetails food7 = new FoodDetails("Pongal", 40, 20);
            FoodDetails food8 = new FoodDetails("Vegetable Briyani", 80, 15);
            FoodDetails food9 = new FoodDetails("Lemon Rice", 50, 30);
            FoodDetails food10 = new FoodDetails("Veg Pulav", 120, 30);
            FoodDetails food11 = new FoodDetails("Chicken 65 (200 Grams)", 75, 30);
            foodList.AddRange(new CustomList<FoodDetails> { food1, food2, food3, food4, food5, food6, food7, food8, food9, food10, food11 });
            //Console.WriteLine("FoodID	FoodName	PricePerQuantity	QuantityAvailable");
            
            //order details
            OrdreDetails order1 = new OrdreDetails("CID1001", 580, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrdreDetails order2 = new OrdreDetails("CID1002", 870, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrdreDetails order3 = new OrdreDetails("CID1001", 820, new DateTime(2022, 11, 26), OrderStatus.Cancelled);
            orderList.Add(order1);
            orderList.Add(order2);
            orderList.Add(order3);
            //Console.WriteLine("OrderID	CustomerID	TotalPrice	DateOfOrder	OrderStatus");
            
            //ItemList
            ItemDetails item1 = new ItemDetails("OID3001", "FID2001", 2, 200);
            ItemDetails item2 = new ItemDetails("OID3001", "FID2002", 2, 300);
            ItemDetails item3 = new ItemDetails("OID3001", "FID2003", 1, 80);
            ItemDetails item4 = new ItemDetails("OID3002", "FID2001", 1, 100);
            ItemDetails item5 = new ItemDetails("OID3002", "FID2002", 4, 600);
            ItemDetails item6 = new ItemDetails("OID3002", "FID2010", 1, 120);
            ItemDetails item7 = new ItemDetails("OID3002", "FID2009", 1, 50);
            ItemDetails item8 = new ItemDetails("OID3003", "FID2002", 2, 300);
            ItemDetails item9 = new ItemDetails("OID3003", "FID2008", 4, 320);
            ItemDetails item10 = new ItemDetails("OID3003", "FID2001", 2, 200);
            //Console.WriteLine("ItemID	OrderID	FoodID	PurchaseCount	PriceOfOrder");
            itemList.AddRange(new CustomList<ItemDetails>{item1,item2,item3,item4,item5,item6,item7,item8,item9,item10});
            

        }
    }
}
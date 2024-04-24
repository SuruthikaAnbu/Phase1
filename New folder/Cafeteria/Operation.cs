using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Cafeteria
{
    public static class Operation
    {
        //list creation
        public static CustomList<PersonalDetails> personalList = new CustomList<PersonalDetails>();
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
        public static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
        public static CustomList<CartItem> cartList = new CustomList<CartItem>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        //current user
        static UserDetails currentCustomer;
        //main menu
        public static void MainMenu()
        {
            Console.WriteLine("--WELCOME TO CAFETERIA MANAGEMENT SYSTEM--");
            bool flag = true;
            do
            {
                Console.WriteLine("---CHOOSE ONE---\n1.User registration\n2.Login\n3.Exit");
                int mainChoice = int.Parse(Console.ReadLine());
                switch (mainChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("--USER REGISTRATION--");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("--USER LOGIN--");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            flag = false;
                            Console.WriteLine("Exit from main menu, Thank you");
                            break;
                        }
                }


            } while (flag);
        }
        //user registration
        public static void Registration()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your father name : ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your mobile number : ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter your mail ID : ");
            string mail = Console.ReadLine();
            Console.Write("Enter your Gender male/female/Transgender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter your work station number : ");
            string workStatopn = Console.ReadLine();
            Console.Write("Enter your balance : ");
            double balance = double.Parse(Console.ReadLine());
            //obj creation
            UserDetails user = new UserDetails(name, fatherName, gender, mobileNumber, mail, workStatopn, balance);
            //add to list
            userList.Add(user);
            Console.WriteLine("Registration successfull and your user ID is ... : " + user.UserID);

        }
        //login 
        public static void Login()
        {
            Console.WriteLine("Enter your user ID : ");
            string checkUserId = Console.ReadLine();
            bool flag = true;
            foreach (UserDetails user in userList)
            {
                if (user.UserID == checkUserId)
                {
                    flag = false;
                    currentCustomer = user;
                    SubMenu();
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid USerID");
            }
        }
        //submenu
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                Console.WriteLine("--CHOOSE ONE--\n1.Show my profile\n2.Food order\n3.Modify order\n4.Cancel order\n5.order history\n6.Wallet Recharge\n7.Show wallet balance\n8.Exit");
                int subMenuChoice = int.Parse(Console.ReadLine());
                switch (subMenuChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("Your profile");
                            ShowMyProfile();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Your order");
                            FoodOrder();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Your modify order");
                            ModifyOrder();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("cancel order");
                            CancelOrder();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("order history");
                            OrderHistory();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Wallet recharge");
                            WalletRecharge();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Wallet balance");
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            flag = false;
                            Console.WriteLine("Exit from sub menu");
                            break;
                        }
                }

            } while (flag);
        }
        //show my profile
        public static void ShowMyProfile()
        {
            Console.WriteLine("||name || father name || Gender || mobile || mail id ||");
            Console.WriteLine("________________________________________________________");
            Console.WriteLine();
            Console.WriteLine($"||{currentCustomer.Name}||{currentCustomer.FatherName}||{currentCustomer.Gender}||{currentCustomer.Mobile}||{currentCustomer.MailID}");
        }
        //food order
        public static void FoodOrder()
        {
            CustomList<CartItem> tempCartList = new CustomList<CartItem>();
            OrderDetails order = new OrderDetails(currentCustomer.UserID, DateTime.Now, 0, OrderStatus.Initiated);
            bool flag = true;
            do
            {
                Console.WriteLine("Food ID || food NAme || food price || Available quantity");
                foreach (FoodDetails foods in foodList)
                {
                    Console.WriteLine($"||{foods.FoodID}||{foods.FoodName}||{foods.FoodPrice}||{foods.AvailableQuantity}||");
                }
                Console.Write("pick the product using food Id : ");
                string chooseFoodId = Console.ReadLine();
                Console.Write("pick the quantity : ");
                int chooseQuantity = int.Parse(Console.ReadLine());
                double totalFoodPrice = 0;
                foreach (FoodDetails foods in foodList)
                {
                    if (foods.FoodID == chooseFoodId)
                    {
                        totalFoodPrice = chooseQuantity * foods.FoodPrice;
                    }
                }
                foreach (FoodDetails foods in foodList)
                {
                    if (foods.FoodID == chooseFoodId)
                    {
                        if (foods.AvailableQuantity >= chooseQuantity)
                        {
                            foods.AvailableQuantity -= chooseQuantity;
                            CartItem cart = new CartItem(order.OrderID, chooseFoodId, totalFoodPrice, chooseQuantity);
                            tempCartList.Add(cart);//doubt
                            Console.WriteLine("do you want to pick another product yes/no : ");
                            string pickChoice = Console.ReadLine().ToUpper();
                            if (pickChoice == "YES")
                            {
                                flag = true;
                                break;
                            }
                            else
                            {
                                flag = false;
                                Console.WriteLine("do you confirm the wishlist to purchase yes / no : ");
                                string confimChoice = Console.ReadLine().ToUpper();
                                double totprice = 0;
                                if (confimChoice == "YES")
                                {
                                    foreach (CartItem items in tempCartList)
                                    {
                                        totprice += items.OrderPrice;
                                    }
                                    Console.WriteLine("total price is" + totprice);
                                    bool finalChoice=true;
                                    do
                                    {
                                        if (currentCustomer._balance > totprice)
                                        {
                                            //currentCustomer._balance -= totprice;
                                            foreach (CartItem items in tempCartList)
                                            {
                                                CartItem carts = new CartItem(items.OrderId, items.FoodID, items.OrderPrice, items.OrderQuantity);
                                                cartList.Add(carts);
                                                order.OrderStatus = OrderStatus.Ordered;
                                                order.TotalPrice = totprice;
                                                orderList.Add(order);
                                            }
                                            Console.WriteLine("Order placed successfully.your order id is" + order.OrderID);
                                            finalChoice=false;
                                            



                                        }
                                        else
                                        {
                                            Console.WriteLine("Insufficient balance to purchase. \n are you willing to reacharge yes/no");
                                            string chooseRecharge = Console.ReadLine().ToUpper();
                                            if (chooseRecharge == "YES")
                                            {
                                                Console.WriteLine("Enter the amount to recharge");
                                                double rechargeMoney = double.Parse(Console.ReadLine());
                                                currentCustomer._balance += rechargeMoney;
                                                if (totprice < currentCustomer._balance)
                                                {
                                                    finalChoice=true;
                                                }
                                            }
                                            else
                                            {
                                                finalChoice=false;
                                                Console.WriteLine("Exiting without order due to insufficient balance");
                                                foreach (CartItem items in tempCartList)
                                                {
                                                    foods.AvailableQuantity += items.OrderQuantity;
                                                }

                                            }

                                        }

                                    } while (finalChoice);
                                }
                                else
                                {
                                    foreach (CartItem localCart in tempCartList)
                                    {
                                        foreach(FoodDetails fod in foodList)
                                        {
                                            if(localCart.FoodID==fod.FoodID)
                                            {
                                                fod.AvailableQuantity += localCart.OrderQuantity;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("food quantity is not available");
                            break;
                        }

                    }
                    /*else
                {
                    Console.WriteLine("mismatching food id");
                }*/

                }


            } while (flag);



        }
        //Modify order
        public static void ModifyOrder()
        {
            Console.WriteLine("order ID || user Id || order date || total price || order status  ||");

            foreach(OrderDetails order in orderList)
            {
                if(currentCustomer.UserID==order.UserID)
                {
                    Console.WriteLine($"||{order.OrderID}||{order.UserID}||{order.OrderDate}||{order.TotalPrice}||{order.OrderStatus}||");
                }
            }
            Console.WriteLine("choose yor order ID");
            string choosenOrderID=Console.ReadLine();
            foreach(OrderDetails order in orderList)
            {
                if(currentCustomer.UserID==order.UserID)
                {
                    if(order.OrderID==choosenOrderID && order.OrderStatus==OrderStatus.Ordered)
                    {
                        Console.WriteLine("Item ID || order Id || food ID || order price || order Quantity  ||");
                        foreach (CartItem cart in cartList)
                        {
                            Console.WriteLine($"||{cart.ItemID}||{cart.OrderId}||{cart.FoodID}||{cart.OrderPrice}||{cart.OrderQuantity}||");
                        }
                        Console.WriteLine("choose the item id");
                        string choosenItemId=Console.ReadLine();
                        int newQuantity;
                        double itemPrice=0;
                        foreach (CartItem cart in cartList)
                        {
                            if(cart.ItemID==choosenItemId)
                            {
                                Console.WriteLine("Enter the new quantity");
                                newQuantity=int.Parse(Console.ReadLine());
                                itemPrice=newQuantity*cart.OrderPrice;
                                cart.OrderPrice=itemPrice;
                                order.TotalPrice=itemPrice;
                                order.OrderDate=DateTime.Now;
                                //OrderDetails order2=new OrderDetails(currentCustomer.UserID,DateTime.Now,itemPrice,OrderStatus.Ordered);
                                Console.WriteLine("order modified successfully");
                            }
                        }


                    }
                }
            }


        }
        //Cancel order
        public static void CancelOrder()
        {
            Console.WriteLine("order ID || user Id || order date || total price || order status  ||");

            foreach(OrderDetails order in orderList)
            {
                if(currentCustomer.UserID==order.UserID && order.OrderStatus==OrderStatus.Ordered)
                {
                    Console.WriteLine($"||{order.OrderID}||{order.UserID}||{order.OrderDate}||{order.TotalPrice}||{order.OrderStatus}||");
                }
            }
            Console.WriteLine("choose the order id to cancel");
            string chooseOrderID=Console.ReadLine();
            bool flag=true;
            foreach(OrderDetails order in orderList)
            {
                if(order.OrderID==chooseOrderID)
                {
                    flag=false;
                    currentCustomer._balance+=order.TotalPrice;
                    foreach(CartItem cart in cartList)
                    {
                        if(cart.OrderId==order.OrderID)
                        {
                            foreach(FoodDetails food in foodList)
                            {
                                if(food.FoodID==cart.FoodID)
                                {
                                    food.AvailableQuantity-=cart.OrderQuantity;
                                    order.OrderStatus=OrderStatus.Cancelled;
                                    Console.WriteLine("Order cancelled successfully");
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid order ID");
            }

        }
        //order history
        public static void OrderHistory()
        {
            Console.WriteLine("order ID || user Id || order date || total price || order status  ||");
            foreach (OrderDetails order in orderList)
            {
                if (currentCustomer.UserID == order.UserID)
                {
                    Console.WriteLine($"||{order.OrderID}||{order.UserID}||{order.OrderDate}||{order.TotalPrice}||{order.OrderStatus}||");
                }
            }

        }
        //Wallet recharge
        public static void WalletRecharge()
        {
            Console.WriteLine("Enter the amount to recharge : ");
            double amount = double.Parse(Console.ReadLine());
            currentCustomer._balance += amount;
            Console.WriteLine("Recharge succssfully.now your cuttent balance is : " + currentCustomer._balance);

        }
        //show wallet balance
        public static void ShowWalletBalance()
        {
            Console.WriteLine("your current balance is : " + currentCustomer._balance);
        }
        //Default data adding
        public static void DefaultData()
        {
            FoodDetails food1 = new FoodDetails("Coffee", 20, 100);
            FoodDetails food2 = new FoodDetails("Tea", 15, 100);
            FoodDetails food3 = new FoodDetails("Biscuits", 10, 100);
            FoodDetails food4 = new FoodDetails("Juice", 50, 100);
            FoodDetails food5 = new FoodDetails("Puff", 40, 100);
            FoodDetails food6 = new FoodDetails("milk", 10, 100);
            FoodDetails food7 = new FoodDetails("PopCorn", 20, 20);
            foodList.AddRange(new CustomList<FoodDetails> { food1, food2, food3, food4, food5, food6, food7 });

            //user details
            UserDetails user1 = new UserDetails("Ravi", "Ettaparajan", Gender.male, "234567876", "ravi@gmail.com", "WS101", 400);
            UserDetails user2 = new UserDetails("Baskaran", "sethurajan", Gender.male, "9876543", "baskar@gmail.com", "WS105", 500);
            userList.AddRange(new CustomList<UserDetails> { user1, user2 });
            Console.WriteLine("user ID || user Name || father name || mobile number || mailID  || Gender  || Work station number || balance");
            foreach (UserDetails user in userList)
            {
                Console.WriteLine($"||{user.UserID}||{user.Name}||{user.FatherName}||{user.Gender}||{user.Mobile}||{user.MailID}||{user.WorkStationNumber}||{user.WalletBalance}");
            }
            //order details
            OrderDetails order1 = new OrderDetails("SF1001", new DateTime(2022, 06, 15), 70, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("SF1002", new DateTime(2022, 06, 15), 100, OrderStatus.Ordered);
            orderList.AddRange(new CustomList<OrderDetails> { order1, order2 });
            Console.WriteLine("order ID || user Id || order date || total price || order status  ||");
            foreach (OrderDetails order in orderList)
            {
                Console.WriteLine($"||{order.OrderID}||{order.UserID}||{order.OrderDate}||{order.TotalPrice}||{order.OrderStatus}||");
            }
            //cart details
            CartItem cart1 = new CartItem("OID1001", "FID101", 20, 1);
            CartItem cart2 = new CartItem("OID1001", "FID101", 20, 1);
            CartItem cart3 = new CartItem("OID1001", "FID101", 20, 1);
            CartItem cart4 = new CartItem("OID1001", "FID101", 20, 1);
            CartItem cart5 = new CartItem("OID1001", "FID101", 20, 1);
            CartItem cart6 = new CartItem("OID1001", "FID101", 20, 1);
            cartList.AddRange(new CustomList<CartItem> { cart1, cart2, cart3, cart4, cart5, cart6 });
            Console.WriteLine("Item ID || order Id || food ID || order price || order Quantity  ||");
            foreach (CartItem cart in cartList)
            {
                Console.WriteLine($"||{cart.ItemID}||{cart.OrderId}||{cart.FoodID}||{cart.OrderPrice}||{cart.OrderQuantity}||");
            }
        }

    }
}
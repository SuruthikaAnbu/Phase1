using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SynCart
{
    public static class Operations
    {
        //list creation
        static List<CustomerDetails> customerList = new List<CustomerDetails>();
        static List<ProductDetails> productList = new List<ProductDetails>();
        static List<OrderDetail> orderList = new List<OrderDetail>();
        static CustomerDetails currentCustomer;
        //main menu
        public static void MainMenu()
        {
            //registration 
            //login
            //exit
            Console.WriteLine("***************WELCOME TO SYNCART************");
            bool flag = true;
            do
            {
                Console.WriteLine("-----SELECT ONE-----\n1. Registration\n2. Login\n3.Exit");
                int mainMenuChoice = int.Parse(Console.ReadLine());
                switch (mainMenuChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("******REGISTRATION*****");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("******LOGIN*****");
                            Console.WriteLine("Enter your customer id");
                            string custId = Console.ReadLine();
                            bool flag1 = true;
                            foreach (CustomerDetails customer in customerList)
                            {
                                if (custId == customer.CustomerID)
                                {
                                    flag1 = false;
                                    currentCustomer = customer;
                                    Login();
                                }
                            }
                            if (flag1)
                            {
                                Console.WriteLine("Invalid customer ID");
                            }

                            break;
                        }
                    case 3:
                        {
                            flag = false;
                            Console.WriteLine("******EXIT FROM MAIN MENU*****");
                            break;
                        }
                }

            } while (flag);

        }
        //Register method
        public static void Registration()
        {
            Console.Write("Enter the customer name : ");
            string customerName = Console.ReadLine();
            Console.Write("Enter the city : ");
            string city = Console.ReadLine();
            Console.Write("Enter the phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter the mail id : ");
            string mailID = Console.ReadLine();
            Console.Write("Enter the wallet balance : ");
            long walletBalance = long.Parse(Console.ReadLine());
            //obj creation'
            CustomerDetails customer = new CustomerDetails(customerName, city, phoneNumber, walletBalance, mailID);
            //adding to a list
            customerList.Add(customer);
            Console.WriteLine("successfully registered! and your customer id is" + customer.CustomerID);



        }
        //Login
        public static void Login()
        {
            bool flag2 = true;
            do
            {
                Console.WriteLine("-----SELECT ONE------\n1.purchase\n2.order history\n3.cancel order\n4.Wallet balance\n5.wallet recharge\n6.exit");
                int subMenuChoice = int.Parse(Console.ReadLine());
                switch (subMenuChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("********purchase*******");
                            Purchase();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("********order history*******");
                            OrderHistory();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("********cancel order*******");
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("********wallet balance*******");
                            WalletBalance();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("********wallet recharge*******");
                            WalletReacharge();
                            break;
                        }
                    case 6:
                        {
                            flag2 = false;
                            Console.WriteLine("********going back to main menu*******");
                            break;
                        }
                }

            } while (flag2);


        }
        //purchase
        public static void Purchase()
        {
            //traversing product list
            Console.WriteLine("ID  |  Name  |  stock | price  |  shipping duration");
            foreach (ProductDetails product in productList)
            {
                Console.WriteLine(product.ProductID + " | " + product.ProductName + " | " + product.Stock + " | " + product.Price + " | " + product.ShippingDuration);
            }
            Console.WriteLine("Select the product ID");
            string getProductId=Console.ReadLine();
            //validate
            bool flag=true;
            
            foreach (ProductDetails product in productList)
            {
                if(getProductId==product.ProductID)
                {
                    flag=false;
                    Console.WriteLine("Enter the count you wish to purchase :");
                    int purchaseCount=int.Parse(Console.ReadLine());
                    if(purchaseCount<product.Stock)
                    {
                        long totalAmount=(purchaseCount*product.Price)+50;
                        if(currentCustomer.WalletBalance>=totalAmount)
                        {
                            currentCustomer.WalletBalance-=totalAmount;
                            product.Stock-=purchaseCount;
                            OrderDetail order1=new OrderDetail(currentCustomer.CustomerID,product.ProductID,totalAmount,DateTime.Now, purchaseCount,OrderStatus.Orderd);
                            Console.WriteLine("Order placed successfully.Order ID is"+order1.OrderID);
                            Console.WriteLine("your delivary date is"+order1.PurchaseDate.AddDays(product.ShippingDuration));

                        }
                        else{
                            Console.WriteLine("Insufficient wallet balance please recharge and try again");
                        }

                    }
                    else{
                        Console.WriteLine("Required count is not available. current availability is"+product.Stock);
                    }

                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid product ID");
            }

        }
        //order history
        public static void OrderHistory()
        {
            //traversing order list
            Console.WriteLine("ID  |  Name  |  stock | price  |  shipping duration");
            foreach (OrderDetail order in orderList)
            {
                if(currentCustomer.CustomerID==order.CustomerID)
                {
                Console.WriteLine(order.OrderID + " | " + order.CustomerID + " | " + order.ProductID + " | " + order.TotalPrice + " | " + order.PurchaseDate + " | " + order.Quantity + " | " + order.OrderStatus);
                }
            }

        }
        //cancel history
        public static void CancelOrder()
        {
            OrderHistory();
            Console.WriteLine("select the order ID for cancel the order");
            string cancelID=Console.ReadLine();
            bool flag=true;
            foreach (OrderDetail order in orderList)
            {
                if(cancelID==order.OrderID)
                {
                    flag=false;
                    foreach(ProductDetails product in productList)
                    {
                        if(order.ProductID==product.ProductID)
                        {
                            product.Stock+=order.Quantity;
                            currentCustomer.WalletBalance+=order.Quantity*product.Price;
                            order.OrderStatus=OrderStatus.Cancelled;
                            Console.WriteLine(order.OrderID+"Cancelled successfully");
                        }
                    }
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid order id");
    
            }


        }
        //Wallet balance
        public static void WalletBalance()
        {
            Console.WriteLine("your current wallet balance is"+currentCustomer.WalletBalance);

        }
        //Wallet Recharge
        public static void WalletReacharge()
        {
            Console.WriteLine("Do you want to recharge yes/no");
            string choice=Console.ReadLine().ToUpper();
            if(choice=="YES")
            {
                Console.WriteLine("Enter the amount to recharge");
                long enteredAmount=long.Parse(Console.ReadLine());
                currentCustomer.WalletBalance+=enteredAmount;
                Console.WriteLine("your current balance is"+currentCustomer.WalletBalance);


            }

        }
        //going back to main menu
        


        //adding default value
        public static void DefaultData()
        {
            //adding customer list default data
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", "9885858588", 50000, "ravi@mail.com");
            customerList.Add(customer1);
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", "9885858588", 60000, "baskaran@mail.com");
            customerList.Add(customer2);
            //adding product list default data
            ProductDetails product1 = new ProductDetails("Mobile (Samsung)", 10, 10000, 3);
            ProductDetails product2 = new ProductDetails("Tablet (Lenovo)", 5, 15000, 2);
            ProductDetails product3 = new ProductDetails("Camara (Sony)", 3, 20000, 4);
            ProductDetails product4 = new ProductDetails("iPhone ", 5, 50000, 6);
            ProductDetails product5 = new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3);
            ProductDetails product6 = new ProductDetails("HeadPhone (Boat)", 5, 1000, 2);
            ProductDetails product7 = new ProductDetails("Speakers (Boat)", 4, 500, 2);
            productList.AddRange(new List<ProductDetails>() { product1, product2, product3, product4, product5, product6, product7 });
            //adding default order list
            OrderDetail order1 = new OrderDetail("CID1001", "PID101", 20000, DateTime.Now, 2, OrderStatus.Orderd);
            OrderDetail order2 = new OrderDetail("CID1002", "PID103", 40000, DateTime.Now, 2, OrderStatus.Orderd);
            orderList.Add(order1);
            orderList.Add(order2);
            //traversing customer list
            Console.WriteLine("Name  |  City  |  MobileNumber | WalletBalance  |  EmailID");
            foreach (CustomerDetails customer in customerList)
            {
                Console.WriteLine(customer.Name + " | " + customer.City + " | " + customer.MobileNumber + " | " + customer.WalletBalance + " | " + customer.EmailID);
            }
            //traversing product list
            Console.WriteLine("ID  |  Name  |  stock | price  |  shipping duration");
            foreach (ProductDetails product in productList)
            {
                Console.WriteLine(product.ProductID + " | " + product.ProductName + " | " + product.Stock + " | " + product.Price + " | " + product.ShippingDuration);
            }
            //traversing order list
            Console.WriteLine("ID  |  Name  |  stock | price  |  shipping duration");
            foreach (OrderDetail order in orderList)
            {
                Console.WriteLine(order.OrderID + " | " + order.CustomerID + " | " + order.ProductID + " | " + order.TotalPrice + " | " + order.PurchaseDate + " | " + order.Quantity + " | " + order.OrderStatus);
            }



        }

    }
}
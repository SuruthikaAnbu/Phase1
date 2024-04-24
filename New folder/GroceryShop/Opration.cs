using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GroceryShop
{
    public static class Opration
    {

        public static CustomList<CustomerRegistration> customerList = new CustomList<CustomerRegistration>();
        public static CustomList<BookingDetails> bookingList = new CustomList<BookingDetails>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        public static CustomList<PersonalDetails> personalList = new CustomList<PersonalDetails>();
        public static CustomList<ProductDetailClass> productList = new CustomList<ProductDetailClass>();
        public static CustomerRegistration currentCustomer;

        //main menu
        public static void MainMenu()
        {

            bool mainFlag = true;
            do
            {
                Console.WriteLine("--ONLINE GROCERRY STORE APPLICATION--");
                Console.WriteLine("--CHOOSE ONE--\n1.Customer Registration\n2.Customer login\n3.Exit");
                int mainChoice = int.Parse(Console.ReadLine());
                switch (mainChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("Registration");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Login");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            mainFlag = false;
                            Console.WriteLine("Exit from main menu");
                            break;
                        }
                }
            } while (mainFlag);
        }

        //Registration
        public static void Registration()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your father name : ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your Gender male/female : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter your mobile : ");
            string mobile = Console.ReadLine();
            Console.Write("Enter your DOB dd/mm/yyyy: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter your mail : ");
            string mail = Console.ReadLine();
            Console.Write("Enter your wallet balance : ");
            double balance = double.Parse(Console.ReadLine());
            CustomerRegistration customer = new CustomerRegistration(name, fatherName, gender, mobile, dob, mail, balance);
            customerList.Add(customer);
            Console.WriteLine("Registtration successful your customer id is : " + customer.CustomerID);
        }
        //Login 
        public static void Login()
        {
            Console.WriteLine("--Log IN--");
            Console.WriteLine("Enter your customer id");
            string checkCustomerID = Console.ReadLine();
            foreach (CustomerRegistration customer in customerList)
            {
                if (customer.CustomerID == checkCustomerID)
                {
                    currentCustomer = customer;
                    SubMenu();
                }
            }
        }

        //submrnu
        public static void SubMenu()
        {
            bool subFlag = true;
            do
            {
                Console.WriteLine("--choose one--\n1.Show customer detail\n2.show product detail\n3.wallet recharge\n4.take order\n5.modify order quantity\n6.cancel order\n7.show balance\n8.Exit");
                int subChoice = int.Parse(Console.ReadLine());
                switch (subChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("Show Customer Details");
                            ShowCustomerDetails();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Show Product Details");
                            ShowProductDetails();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Wallet Recharge");
                            WalletRecharge();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Take Order");
                            TakeOrder();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Modify Order Quantity");
                            ModifyOrderQuantity();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Cancel Order");
                            CancelOrder();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Show Balance");
                            ShowBalance();
                            break;
                        }
                    case 8:
                        {
                            subFlag = false;
                            Console.WriteLine("Exit from submenu");
                            break;
                        }
                }

            } while (subFlag);
        }
        public static void ShowCustomerDetails()
        {
            Console.WriteLine("customer id | name | father name | gender | mobile | DOB | mail | wallet balance");
            foreach (CustomerRegistration customer in customerList)
            {
                if (customer.CustomerID == currentCustomer.CustomerID)
                {
                    Console.WriteLine($"{customer.CustomerID}|{customer.Name}|{customer.FatherName}|{customer.Gender}|{customer.Mobile}{customer.DOB.ToString("dd/MM/yyyy")}|{customer.MailID}|{customer.WalletBalance}");
                }
            }

        }
        public static void ShowProductDetails()
        {
            Console.WriteLine("product id | product name | quantity available | price per quantity");
            foreach (ProductDetailClass product in productList)
            {
                Console.WriteLine($"{product.ProductID}| {product.ProductName}| {product.QuantityAvailable}| {product.PricePerQuantity}");
            }

        }
        public static void WalletRecharge()
        {
            Console.WriteLine("Enter the amount to recharge");
            double amount = double.Parse(Console.ReadLine());
            foreach (CustomerRegistration customer in customerList)
            {
                if (customer.CustomerID == currentCustomer.CustomerID)
                {
                    customer.WalletRecharge(amount);
                    Console.WriteLine("your current balance is " + customer.WalletBalance);
                }
            }
        }
        public static void TakeOrder()
        {
            Console.WriteLine("Do you want to purchase or not yes/no");
            string userChoice = Console.ReadLine().ToUpper();
            if (userChoice == "YES")
            {
                BookingDetails tempBookObj = new BookingDetails(currentCustomer.CustomerID, 0, DateTime.Now, BookingStatus.initiated);
                List<OrderDetails> tempOrderList = new List<OrderDetails>();
                string userChoice1="YES";
                double Totalamount = 0;
                do
                {
                    Console.WriteLine("product id | product name | quantity available | price per quantity");
                    foreach (ProductDetailClass product in productList)
                    {
                        Console.WriteLine($"{product.ProductID}| {product.ProductName}| {product.QuantityAvailable}| {product.PricePerQuantity}");
                    }
                    Console.WriteLine("choose one product id");
                    string chooseProductId = Console.ReadLine();
                    bool productflag = true;
                    
                    
                    foreach (ProductDetailClass product in productList)
                    {
                        if (chooseProductId == product.ProductID)
                        {
                            productflag = false;
                            Console.WriteLine("Enter the purchase quantity : ");
                            int choosenPurchaseQuantity = int.Parse(Console.ReadLine());
                            {
                                if (product.QuantityAvailable > choosenPurchaseQuantity)
                                {
                                    double amount=0;
                                    amount+= product.PricePerQuantity * choosenPurchaseQuantity;
                                    Totalamount+=amount;
                                    OrderDetails order = new OrderDetails(tempBookObj.BookID, chooseProductId, choosenPurchaseQuantity, amount);
                                    tempOrderList.Add(order);
                                    product.QuantityAvailable -= choosenPurchaseQuantity;
                                    Console.WriteLine("product successfully added to card total amount is : " + Totalamount+"---"+  amount);
                                    Console.WriteLine("do you want to purchase another product.. yes/no");
                                    userChoice1 = Console.ReadLine().ToUpper();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("not available quantity");
                                    break;
                                }
                            }

                        }
                    }
                    if (productflag)
                    {
                        Console.WriteLine("invalid product id");

                    }

                } while (userChoice1=="YES");
                Console.WriteLine("Do you want to confirm the order yes/no");
                string orderConfimation=Console.ReadLine().ToUpper();
                if(orderConfimation=="YES")
                {
                    if(currentCustomer.WalletBalance>=Totalamount)
                    {
                        currentCustomer.WalletBalance-=Totalamount;
                        tempBookObj.BookingStatus=BookingStatus.booked;
                        tempBookObj.TotalPrice=Totalamount;
                        bookingList.Add(tempBookObj);
                        foreach(OrderDetails ord1 in tempOrderList)
                        {
                            OrderDetails order=new OrderDetails(ord1.BookingID,ord1.ProductID,ord1.PurchaseCount,ord1.PriceOfOrder);
                            orderList.Add(order);
                        }
                        Console.WriteLine("booking Successful");
                    }
                    else{
                        
                        Console.WriteLine("Insufficient balance.recharge now");
                        WalletRecharge();
                        
                    }
                }
                else{
                    
                    foreach(OrderDetails ord1 in tempOrderList)
                    {
                        foreach (ProductDetailClass product in productList)
                        {
                            if(product.ProductID==ord1.ProductID)
                            {
                                product.QuantityAvailable+=ord1.PurchaseCount;
                            }
                        }
                            
                    }
                    Console.WriteLine("cart removed successfully...");
                    
                }

            }
           

        }
        public static void ModifyOrderQuantity()
        {
            Console.WriteLine("Order id | booking ID | product Id | purchase count | price");
            
           // Console.WriteLine("book id | customer id | total price | date of booking | booking status");
            foreach (BookingDetails book in bookingList)
            {
                if(currentCustomer.CustomerID==book.CustomerID && book.BookingStatus==BookingStatus.booked)
                {
                    foreach (OrderDetails order in orderList)
                    {
                        if(book.BookID==order.BookingID)
                        {
                        Console.WriteLine($"{order.OrderID} | {order.BookingID} | {order.ProductID} | {order.PurchaseCount} | {order.PriceOfOrder}");
                        }
                    }
                }
            }
            Console.WriteLine("Pickt the order id");
            string userPickOrderID=Console.ReadLine();
            foreach (OrderDetails order in orderList)
            {
                if(order.OrderID==userPickOrderID)
                {
                    Console.WriteLine("Enyter the new quantity of the order");
                    int ordQuantit=int.Parse(Console.ReadLine());
                    double price=ordQuantit*order.PriceOfOrder;
                    order.PurchaseCount=ordQuantit;
                    
                    foreach(ProductDetailClass product in productList)
                    {
                        if(order.ProductID==product.ProductID)
                        {
                            price=product.PricePerQuantity*ordQuantit;
                        }
                    }
                    order.PriceOfOrder=price;
                    foreach (BookingDetails book in bookingList)
                    {
                        if(currentCustomer.CustomerID==book.CustomerID && order.BookingID==book.BookID)
                        {
                            book.TotalPrice=price;
                            Console.WriteLine("Order modified successfully...");
                        }
                    }
                }
            }
            

        }
        public static void CancelOrder()
        {
            Console.WriteLine("book id | customer id | total price | date of booking | booking status");
            foreach (BookingDetails book in bookingList)
            {
                if(currentCustomer.CustomerID==book.CustomerID && book.BookingStatus==BookingStatus.booked)
                {
                    Console.WriteLine($"{book.BookID} {book.CustomerID} {book.TotalPrice} {book.DateOfBooking.ToString("dd/MM/yyyy")} {book.BookingStatus}");
                }
            }
            Console.WriteLine("choose one booking id");
            string pickBookId=Console.ReadLine();
            foreach (BookingDetails book in bookingList)
            {
                if(pickBookId==book.BookID && currentCustomer.CustomerID==book.CustomerID && book.BookingStatus==BookingStatus.booked)
                {
                    book.BookingStatus=BookingStatus.cancelled;
                    currentCustomer.WalletBalance+=book.TotalPrice;
                    Console.WriteLine("order cancalled and amount refubnded.now total balance is "+currentCustomer.WalletBalance);
                    foreach(OrderDetails ord in orderList)
                    {
                        if(ord.BookingID==book.BookID)
                        {
                            int prc=ord.PurchaseCount;
                            foreach(ProductDetailClass product1 in productList)
                            {
                                if(ord.OrderID==product1.ProductID)
                                {
                                    product1.QuantityAvailable+=prc;
                                    Console.WriteLine("cancelled successfully..");
                                }
                            }
                        }
                    }
                }
            }


        }
        public static void ShowBalance()
        {
            foreach (CustomerRegistration customer in customerList)
            {
                if (customer.CustomerID == currentCustomer.CustomerID)
                {
                    Console.WriteLine("your current balance is " + customer.WalletBalance);
                }
            }
        }

        public static void DefaultData()
        {
            //customerRegistration
            CustomerRegistration customer1 = new CustomerRegistration("Ravi", "Ettaparajan", Gender.male, "567890987", new DateTime(1999, 11, 11), "ravi@gmail.com", 10000);
            CustomerRegistration customer2 = new CustomerRegistration("Baskaran", "sethurajan", Gender.male, "98798987", new DateTime(1999, 11, 11), "baskaran@gmail.com", 15000);
            //customerList.Add(customer1);
            //customerList.Add(customer2);
            customerList.AddRange(new CustomList<CustomerRegistration> { customer1, customer2 });

            Console.WriteLine("customer id | name | father name | gender | mobile | DOB | mail | wallet balance");
            foreach (CustomerRegistration customer in customerList)
            {
                Console.WriteLine($"{customer.CustomerID}|{customer.Name}|{customer.FatherName}|{customer.Gender}|{customer.Mobile}{customer.DOB.ToString("dd/MM/yyyy")}|{customer.MailID}|{customer.WalletBalance}");
            }
            //ProductDetails
            ProductDetailClass product1 = new ProductDetailClass("sugar", 20, 40);
            ProductDetailClass product2 = new ProductDetailClass("rice", 100, 50);
            ProductDetailClass product3 = new ProductDetailClass("milk", 10, 40);
            ProductDetailClass product4 = new ProductDetailClass("coffee", 10, 10);
            ProductDetailClass product5 = new ProductDetailClass("tea", 10, 10);
            ProductDetailClass product6 = new ProductDetailClass("masala powder", 10, 20);
            ProductDetailClass product7 = new ProductDetailClass("salt", 10, 10);
            ProductDetailClass product8 = new ProductDetailClass("turmeric powder", 10, 25);
            ProductDetailClass product9 = new ProductDetailClass("chilli powder", 10, 20);
            ProductDetailClass product10 = new ProductDetailClass("Groundnut oil", 10, 140);
            //add
            productList.AddRange(new CustomList<ProductDetailClass> { product1, product2, product3, product4, product5, product6, product7, product8, product9, product10 });

            Console.WriteLine("product id | product name | quantity available | price per quantity");
            foreach (ProductDetailClass product in productList)
            {
                Console.WriteLine($"{product.ProductID}| {product.ProductName}| {product.QuantityAvailable}| {product.PricePerQuantity}");
            }

            //booking details
            BookingDetails book1 = new BookingDetails("CID1001", 220, new DateTime(2022, 07, 26), BookingStatus.booked);
            BookingDetails book2 = new BookingDetails("CID1002", 400, new DateTime(2022, 07, 26), BookingStatus.booked);
            BookingDetails book3 = new BookingDetails("CID1001", 280, new DateTime(2022, 07, 26), BookingStatus.cancelled);
            BookingDetails book4 = new BookingDetails("CID1002", 0, new DateTime(2022, 07, 26), BookingStatus.initiated);
            bookingList.AddRange(new CustomList<BookingDetails> { book1, book2, book3, book4 });

            Console.WriteLine("book id | customer id | total price | date of booking | booking status");
            foreach (BookingDetails book in bookingList)
            {
                Console.WriteLine($"{book.BookID} {book.CustomerID} {book.TotalPrice} {book.DateOfBooking.ToString("dd/MM/yyyy")} {book.BookingStatus}");
            }

            //order details
            OrderDetails order1 = new OrderDetails("BID3001", "PID2001", 2, 80);
            OrderDetails order2 = new OrderDetails("BID3001", "PID2002", 2, 100);
            OrderDetails order3 = new OrderDetails("BID3001", "PID2003", 1, 40);
            OrderDetails order4 = new OrderDetails("BID3002", "PID2001", 1, 40);
            OrderDetails order5 = new OrderDetails("BID3002", "PID2002", 4, 200);
            OrderDetails order6 = new OrderDetails("BID3002", "PID2010", 1, 140);
            OrderDetails order7 = new OrderDetails("BID3002", "PID2009", 1, 20);
            OrderDetails order8 = new OrderDetails("BID3003", "PID2002", 2, 100);
            OrderDetails order9 = new OrderDetails("BID3003", "PID2008", 4, 100);
            OrderDetails order10 = new OrderDetails("BID3031", "PID2001", 2, 80);
            orderList.AddRange(new CustomList<OrderDetails> { order1, order2, order3, order4, order5, order6, order7, order8, order9, order10 });

            Console.WriteLine("Order id | booking ID | product Id | purchase count | price");
            foreach (OrderDetails order in orderList)
            {
                Console.WriteLine($"{order.OrderID} | {order.BookingID} | {order.ProductID} | {order.PurchaseCount} | {order.PriceOfOrder}");
            }


        }

    }
}
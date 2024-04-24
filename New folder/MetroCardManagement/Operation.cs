using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public static  class Operation
    {
        public static CustomList<PersonalDetails> personalList=new CustomList<PersonalDetails>();
        public static CustomList<TicketFair> ticketFairList=new CustomList<TicketFair>();
        public static CustomList<TravelDetails> travelDetailList=new CustomList<TravelDetails>();
        public static CustomList<UserDetails> userDetailsList=new CustomList<UserDetails>();
        public static UserDetails currentCustomer;
        //main menu
        public static void MainMenu()
        {
            Console.WriteLine("****METRO CARD MANAGEMENT SYSTEM");
            bool mainFlag=true;
            do{
                Console.WriteLine("---CHOOSE ONE---\n1.New user registration\n2.Login user\n3.Exit");
                int mainChoice=int.Parse(Console.ReadLine());
                switch(mainChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("--User registration--");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("--User Login--");
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("--Exit from main menu--");
                        mainFlag=false;
                        break;
                    }
                }

            }while(mainFlag);

        }
        //registration method
        public static void Registration()
        {
            Console.Write("Enter the user name : ");
            string name=Console.ReadLine();
            Console.Write("Enter your phone number : ");
            string phoneNumber=Console.ReadLine();
            Console.Write("Enter the balance : ");
            double balance=double.Parse(Console.ReadLine());
            //object creation
            UserDetails user=new UserDetails(name,phoneNumber,balance);
            //added to list
            userDetailsList.Add(user);
            Console.WriteLine("Registration successful\n your card number is : "+user.CardNumber);
        }
        //login method
        public static void Login()
        {
            Console.WriteLine("Enter your card number");
            string checkCardNo=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(UserDetails user in userDetailsList)
            {
                if(user.CardNumber==checkCardNo)
                {
                    flag=false;
                    currentCustomer=user;
                    SubMenu();
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid card number");
            }
        }
        //submenu
        public static void SubMenu()
        {
            bool subFlag=true;
            do
            {
                Console.WriteLine("--Sub menu choices--\n1.Balance check\n2.Recharge\n3.View travel history\n4.Travel\n5.Exit");
                int subChoice=int.Parse(Console.ReadLine());
                switch(subChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("balance check");
                        BalanceCheck();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Recharge");
                        Recharge();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("View travel history");
                        ViewTravelHistory();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Travel");
                        Travel();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Exit from sub menu");
                        subFlag=false;
                        break;
                    }
                }

            
            }while(subFlag);
        }
        //balance check
        public static void BalanceCheck()
        {   
            //Console.WriteLine("card number | user name| phone | balance");
            foreach(UserDetails user in userDetailsList)
            {
                if(user.CardNumber==currentCustomer.CardNumber)
                {
                    Console.WriteLine("your balance amount is : "+user.Balance);
                    break;
                }
            }

        }
        //Recharge()
        public static void Recharge()
        {
            foreach(UserDetails user in userDetailsList)
            {
                if(user.CardNumber==currentCustomer.CardNumber)
                {
                    Console.Write("Enter the amount to recharge :");
                    double amount=double.Parse(Console.ReadLine());
                    user.WalletRecharge(amount);
                    Console.WriteLine("your balance amount is : "+user.Balance);
                    break;
                }
            }
        }
        //view travel hoistory
        public static void ViewTravelHistory()
        {
            bool flag=true;
            Console.WriteLine("Travel id |card number|from location|to location|date  |travel cost");
            foreach(TravelDetails travel in travelDetailList)
            {
                if(travel.CardNumber==currentCustomer.CardNumber)
                {
                    flag=false;
                    Console.WriteLine($"|{travel.TravelID}  |{travel.CardNumber}   |{travel.FromLocation}     |{travel.ToLocation}|{travel.Date.ToString("dd/MM/yyyy")}|{travel.TravelCost}");
                }
            }
            if(flag)
            {
                Console.WriteLine("You did not have any travel history :-) ");
            }

        }
        //travel
        public static void Travel()
        {
            //show
            Console.WriteLine("|Ticket id | from location | To location | fair");
            foreach(TicketFair ticket in ticketFairList)
            {
                Console.WriteLine($"{ticket.TicketID} |{ticket.FromLocation} |{ticket.ToLocation}  |{ticket.TicketPrice}  ");
            }
            Console.Write("Enter the ticket ID : ");
            string checkTicketID=Console.ReadLine();
            bool flag=true;
            foreach(TicketFair ticket in ticketFairList)
            {
                if(ticket.TicketID==checkTicketID)
                {
                    flag=false;
                    Console.WriteLine("Ticket ID is valid and ticket cost is : "+ticket.TicketPrice);
                    if(ticket.TicketPrice<=currentCustomer.Balance)
                    {
                        Console.WriteLine("Sufficient balance");
                        currentCustomer.Balance-=ticket.TicketPrice;
                        Console.WriteLine(" ticket booked successfully and your current balance is "+currentCustomer.Balance);
                        TravelDetails trvel=new TravelDetails(currentCustomer.CardNumber,ticket.FromLocation,ticket.ToLocation,DateTime.Now,ticket.TicketPrice);
                        travelDetailList.Add(trvel);
                        
                    }
                    else{
                        Console.WriteLine("you did not have a sufficient balance. Do you want to recharge Yes/No:");
                        string rechargeChoice=Console.ReadLine().ToUpper();
                        if(rechargeChoice=="YES")
                        {
                            Recharge();
                        }
                        else{
                            Console.WriteLine("Thank you");
                            break;
                        }
                    }
                }
            }
            if(flag)
            {
                Console.WriteLine("In valid Ticket ID");
            }


        }


        public static void AddDefaultData()
        {
            //user details
            UserDetails user1=new UserDetails("Ravi","9848812345",1000);
            UserDetails user2=new UserDetails("Baskaran","9948854321",1000);
            //adding
            userDetailsList.Add(user1);
            userDetailsList.Add(user2);

            //printing details
            /*
            Console.WriteLine("card number | user name| phone | balance");
            foreach(UserDetails user in userDetailsList)
            {
                Console.WriteLine($"{user.CardNumber}|{user.UserName}|{user.PhoneNumber}|{user.Balance}");
            }
            */

            //Travel history
            TravelDetails travel1=new TravelDetails("CMRL1001","Airport","Egmore",new DateTime(2023,10,10),55);
            TravelDetails travel2=new TravelDetails("CMRL1001","Egmore","Koyembedu",new DateTime(2023,10,10),32);
            TravelDetails travel3=new TravelDetails("CMRL1002","Alandur","Koyembedu",new DateTime(2023,11,10),25);
            TravelDetails travel4=new TravelDetails("CMRL1002","Egmore","Thirumangalam",new DateTime(2023,11,10),25);
            travelDetailList.AddRange(new CustomList<TravelDetails>{travel1,travel2,travel3,travel4});
            //printing details
            /*
            Console.WriteLine("Travel id|card number|from location|to location|date|travel cost");
            foreach(TravelDetails travel in travelDetailList)
            {
                Console.WriteLine($"|{travel.TravelID}|{travel.CardNumber}|{travel.FromLocation}|{travel.ToLocation}|{travel.Date.ToString("dd/MM/yyyy")}|{travel.TravelCost}");
            }*/
            //Ticker fair
            TicketFair ticket1=new TicketFair("Airport","Egmore",55);
            TicketFair ticket2=new TicketFair("Airport","Koyembeu",25);
            TicketFair ticket3=new TicketFair("Alandur","Koyembeu",25);
            TicketFair ticket4=new TicketFair("Koyembeu","Egmore",32);
            TicketFair ticket5=new TicketFair("Vadapalani","Egmore",45);
            TicketFair ticket6=new TicketFair("Arumbakkam","Egmore",25);
            TicketFair ticket7=new TicketFair("Vadapalani","Koyembeu",25);
            TicketFair ticket8=new TicketFair("Arumbakkam","Koyembeu",16);
            ticketFairList.AddRange(new CustomList<TicketFair>{ticket1,ticket2,ticket3,ticket4,ticket5,ticket6,ticket7,ticket8});
            /*
            Console.WriteLine("Ticket id | from location | To location | fair");
            foreach(TicketFair ticket in ticketFairList)
            {
                Console.WriteLine($"{ticket.TicketID}|{ticket.FromLocation}|{ticket.ToLocation}|{ticket.TicketPrice}");
            }
            */

        }
    }
}
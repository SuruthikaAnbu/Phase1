using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public static class Operations
    {
        static List<UserDetails> userList=new List<UserDetails>();
        static List<BookDetails> bookList=new List<BookDetails>();
        static List<BorrowDetails> borrowList=new List<BorrowDetails>();
        static UserDetails currentUSer;
        //creating main menu
        public static void MainMenu()
        {
            Console.WriteLine("**********Welcome to Syncfusion library******");
            /*The Main menu must have the following options.
            1.	UserRegistration
            2.	UserLogin
            3.	Exit*/
            //main menu starts
            bool flag=true;
            do
            {
                Console.WriteLine("**********Main Menu********\n-----SELECT ONE-------\n1. User Registration\n2. User Login\n3. Exit");
                int mainMenuChoice=int.Parse(Console.ReadLine());
                switch(mainMenuChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("******************user Registration**************");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("******************user Login**************");
                        LogIn();
                        break;
                    }
                    case 3:
                    {
                        flag=false;
                        Console.WriteLine("******************Exit from main menu**************");
                        break;
                    }
                }

            }while(flag);//main menu ends


        }
        //registration methos starts
        public static void Registration()
        {
            Console.Write("Enter your name : ");
            string userName=Console.ReadLine();
            Console.Write("Enter your Gender Male/Female/Transgender : ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your Department ECE/EEE/CSE : ");
            Department department=Enum.Parse<Department>(Console.ReadLine(),true);
            Console.Write("Enter your Mobile number : ");
            string mobileNumber=Console.ReadLine();
            Console.Write("Enter your MailID : ");
            string mailID=Console.ReadLine();
            Console.Write("Enter your WalletBalance : ");
            long wallwtBalance=long.Parse(Console.ReadLine());
            //object creation
            UserDetails users=new UserDetails(userName,gender,department,mobileNumber,mailID,wallwtBalance);
            //adding to list
            userList.Add(users);
            Console.WriteLine("Registration successful and your user id is:"+users.UserID);
            //user details
            Console.WriteLine($"UserID	UserName	Gender	Department	MobileNumber	MailID	WalletBalance");
            /*
            foreach(UserDetails user in userList)
            {
                Console.WriteLine($"{user.UserID}|{user.UserName}|{user.Gender}|{user.Department}|{user.MobileNumber}|{user.MailID}|{user.WalletBalance}");
            }*/

            //show

        }//registration ends

        //Login starts
        public static void LogIn()
        {
            Console.Write("Enter your user ID : ");
            string checkUSerID=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(UserDetails user in userList)
            {
                if(checkUSerID==user.UserID)
                {
                    flag=false;
                    currentUSer=user;
                    SubMenu();

                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid user id !!! please enter the valid one");
            }

        }//Login ends

        //submenu
        public static void  SubMenu()
        {
            bool flag=true;
            do{
                Console.WriteLine("*******SUBMENU********\n-----SELECT ONE-----\n1. Borrow book\n2.show borrow history\n3.Return book\n4.Wallet recharge\n5.Exit");
                int subMenuChoice=int.Parse(Console.ReadLine());
                switch(subMenuChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("Borrow book");
                        BorrowBook();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("show Borrow History");
                        ShowBorrowHistory();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Return book");
                        ReturnBook();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Wallet recharge");
                        WalletRecharge();
                        break;
                    }
                    case 5:
                    {
                        flag=false;
                        Console.WriteLine("Exit from sub menu");
                        break;
                    }
                }
            }while(flag);


        }
        
        
        //borrrow book
        public static void BorrowBook()
        {
            //BookDetails
            Console.WriteLine("BookID	BookName	AuthorName	 BookCount");
            foreach(BookDetails book in bookList)
            {
                Console.WriteLine(book.BookID+"|"+book.BookName+"|"+book.AuthorName+"|"+book.BookCount);
            }
            Console.WriteLine("Choose one book id");
            string bookID=Console.ReadLine();
            bool flag2=true;
            foreach(BookDetails book in bookList)
            {
                if(bookID==book.BookID)
                {
                    flag2=false;
                    Console.WriteLine("Enter the count of the book");
                    int bookCount=int.Parse(Console.ReadLine());
                    //check book count
                    string borrowuserId="";
                    if(bookCount>book.BookCount)
                    {
                        Console.WriteLine("books are not available for the selected count");
                        //next available date
                        foreach(BorrowDetails borrow in borrowList)
                        {
                            if(bookID==borrow.BookID)
                            {
                                Console.WriteLine("the next available date is"+borrow.BorrowDate.AddDays(15).ToString("dd/MM/yyyy"));
                                borrowuserId=borrow.UserID;
                            }
                        }

                    }
                    int count2=0;
                    int totalBookcount=0;
                    if(bookCount<book.BookCount)
                    {
                        foreach(BorrowDetails borrow1 in borrowList)
                        {
                            if(currentUSer.UserID==borrow1.UserID)
                            {
                                
                                totalBookcount=borrow1.BookCount+bookCount;
                                if(totalBookcount>3)
                                {
                                    count2++;
                                    Console.WriteLine($"you can have maximum of three borrwed book.your already borrowed book count is {borrow1.BookCount} and requested count is{bookCount} which exceeds 3");

                                }
                                /*else{
                                    BorrowDetails borrow5=new BorrowDetails(bookID,currentUSer.UserID,DateTime.Now,bookCount,Status.Borrowed,0);
                                    borrowList.Add(borrow5);
                                    Console.WriteLine("Book borrwed successfully");
                                    book.BookCount-=bookCount;
                                }*/
                            }
                        }
                    }
                    if(count2==0 && totalBookcount<3)
                    {
                        BorrowDetails borrow1=new BorrowDetails(bookID,currentUSer.UserID,DateTime.Now,bookCount,Status.Borrowed,0);
                        borrowList.Add(borrow1);
                        Console.WriteLine("Book borrwed successfully and your borrow id is"+borrow1.BorrrowID);
                        book.BookCount-=bookCount;

                    }

                }
            }
            if(flag2)
            {
                Console.WriteLine("invalid book id please enter the valid one");
            }


        }
        public static void ShowBorrowHistory()
        {
            Console.WriteLine("BorrowID	BookID	UserID	BorrowedDate	BorrowBookCount	Status	PaidFineAmount");
            foreach(BorrowDetails borrow in borrowList)
            {
                if(currentUSer.UserID==borrow.UserID)
                {
                    Console.WriteLine($"{borrow.BorrrowID}	{borrow.BookID}	{borrow.UserID}	{borrow.BorrowDate}	{borrow.BookCount}	{borrow.Status}	{borrow.PaidFineAmount}");
                }
            }


        }
        public static void ReturnBook()
        {
            //show borrow details
            Console.WriteLine("BorrowID	BookID	UserID	BorrowedDate	BorrowBookCount	Status	PaidFineAmount Return date");
            foreach(BorrowDetails borrow in borrowList)
            {
                if(currentUSer.UserID==borrow.UserID && borrow.Status==Status.Borrowed)
                {
                    Console.WriteLine($"{borrow.BorrrowID}	{borrow.BookID}	{borrow.UserID}	{borrow.BorrowDate}	{borrow.BookCount}	{borrow.Status}	{borrow.PaidFineAmount} {borrow.BorrowDate.AddDays(15)}");
                }
            }
            bool flag=true;
            foreach(BorrowDetails borrow in borrowList)
            {
                int elapsed=0;
                if(currentUSer.UserID==borrow.UserID && borrow.Status==Status.Borrowed)
                {
                    TimeSpan CheckElapsed=DateTime.Now -borrow.BorrowDate;
                    elapsed=(int)CheckElapsed.TotalDays;
                    if(elapsed>15)
                    {
                        Console.WriteLine("Fine amount is"+elapsed);
                        
                    }
                }
                Console.WriteLine("Enter your borrow id");
                string checkBorrowId=Console.ReadLine();
                
                if(checkBorrowId==borrow.BorrrowID)
                {
                    flag=false;
                    if(elapsed>15)
                    {
                        if(currentUSer.WalletBalance>elapsed)
                        {
                            Console.WriteLine("paid fine amount");
                            //deduct balance
                            currentUSer.DeductBalance(elapsed);
                            borrow.Status=Status.Returned;
                            borrow.BookCount--;
                            break;
                        }
                        else{
                            Console.WriteLine("Insufficient balance plz recharge and try agin!!");
                            break;
                        }
                    }
                    else{
                        Console.WriteLine("Book returned successfully");
                        borrow.BookCount--;
                    }

                }
              
                
            }
            if(flag)
            {
                Console.WriteLine("Wrong borrow id");
                
            }

            
            

        }
        public static void WalletRecharge()
        {
            Console.WriteLine("Do you want to recharge the wallet yes/no");
            string checkRecharge=Console.ReadLine().ToUpper();
            if(checkRecharge=="YES")
            {
                Console.WriteLine("Enter amount to recharge");
                long rechargeAmount=long.Parse(Console.ReadLine());
                foreach(UserDetails user in userList)
                {
                    if(currentUSer.UserID==user.UserID)
                    {
                        user.WalletRecharge(rechargeAmount);
                    }
                }
                Console.WriteLine("Recharge successfully. your current wallet balance is"+currentUSer.WalletBalance);

            }
            

        }
        
        
        
        //adding default data
        public static void DefaultData()
        {
            //adding default data
            /*UserID	UserName	Gender	Department	MobileNumber	MailID	WalletBalance

            SF3001	Ravichandran 	Male	EEE	9938388333	ravi@gmail.com
            100
            SF3002	Priyadharshini	Female	CSE	9944444455	priya@gmail.com
            150
            */
            //UserDetails default data
            UserDetails user1=new UserDetails("Ravichandran",Gender.Male,Department.EEE,"9938388333","ravi@gmail.com",100);
            UserDetails user2=new UserDetails("Priyadharshini",Gender.Female,Department.CSE,"9944444455","priya@gmail.com",150);
            userList.Add(user1);
            userList.Add(user2);
            //Book details
                        /*BookID	BookName	AuthorName	 BookCount
            BID1001	C# 	Author1	3
            BID1002	HTML	Author2	5
            BID1003	CSS	Author1	3
            BID1004	JS	Author1	3
            BID1005	TS	Author2	2*/
            BookDetails book1=new BookDetails("C#","Author1",3);
            BookDetails book2=new BookDetails("HTML","Author2",3);
            BookDetails book3=new BookDetails("CSS","Author1",3);
            BookDetails book4=new BookDetails("JS","Author1",3);
            BookDetails book5=new BookDetails("TS","Author2",3);
            //adding to a list
            bookList.Add(book1);
            bookList.Add(book2);
            bookList.Add(book3);
            bookList.Add(book4);
            bookList.Add(book5);
            //Borrow details
                        /*BorrowID	BookID	UserID	BorrowedDate	BorrowBookCount	Status	PaidFineAmount
            LB2001	BID1001	SF3001	10/09/2023	2	Borrowed	0
            LB2002	BID1003	SF3001	12/09/2023	1	Borrowed	0
            LB2003	BID1004	SF3001	14/09/2023	1	Returned	16
            LB2004	BID1002	SF3002	11/09/2023	2	Borrowed	0
            LB2005	BID1005	SF3002	09/09/2023	1	Returned	20
            */
            BorrowDetails borrow1=new BorrowDetails("BID1001","SF3001",new DateTime(2023,09,10),2,Status.Borrowed,0);
            BorrowDetails borrow2=new BorrowDetails("BID1003","SF3001",new DateTime(2023,09,12),1,Status.Borrowed,0);
            BorrowDetails borrow3=new BorrowDetails("BID1004","SF3001",new DateTime(2023,09,14),1,Status.Borrowed,16);
            BorrowDetails borrow4=new BorrowDetails("BID1002","SF3002",new DateTime(2023,09,11),2,Status.Borrowed,0);
            BorrowDetails borrow5=new BorrowDetails("BID1005","SF3002",new DateTime(2023,09,09),1,Status.Returned,20);
            borrowList.Add(borrow1);
            borrowList.Add(borrow2);
            borrowList.Add(borrow3);
            borrowList.Add(borrow4);
            borrowList.Add(borrow5);

            //printing details
            //user details
            Console.WriteLine($"UserID	UserName	Gender	Department	MobileNumber	MailID	WalletBalance");
            foreach(UserDetails user in userList)
            {
                Console.WriteLine($"{user.UserID}|{user.UserName}|{user.Gender}|{user.Department}|{user.MobileNumber}|{user.MailID}|{user.WalletBalance}");
            }
            
            


        }
        
    }
}
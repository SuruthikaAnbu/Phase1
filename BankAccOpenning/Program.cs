using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
namespace BankAccOpenning;
class Program
{
    public static void Main(string[] args)
    {
        
        List<CustomerDetail> customerList = new List<CustomerDetail>();
        string option = "";

        do
        {
            Console.WriteLine("--Welcome to HDFC Bank--\n click 1 for registration \n click 2 for login \n click 3 for exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        CustomerDetail customer1 = new CustomerDetail();
                        //CustomerDetail.Learn();
                        //customer1._CustomerId;--inaccess due to protection level;
                        //customer1.CustomerId="ksdka";
                        //Console.WriteLine("enter your customer id");
                        //customer1.CustomerId = Console.ReadLine();
                        Console.WriteLine("enter your customer name");
                        customer1.CustomerName = Console.ReadLine();
                        Console.WriteLine("enter your balance");
                        customer1.Balance = long.Parse(Console.ReadLine());
                        Console.WriteLine("enter your Gender",true);
                        Gender Gender =Enum .Parse<Gender>(Console.ReadLine(),true);//Gender.Male;// Enum.Parse <Gender>(Console.ReadLine(),true);
                        Console.WriteLine("enter your phone");
                        customer1.Phone = long.Parse(Console.ReadLine());
                        Console.WriteLine("enter your mail id");
                        customer1.MailId = Console.ReadLine();
                        Console.WriteLine("enter your dob dd/MM/yyyy");
                        customer1.DOB = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        customerList.Add(customer1);
                        Console.WriteLine("Your customer id is"+customer1.CustomerId);

                        Console.WriteLine("Do u want to continue Yes/no");
                        option = Console.ReadLine().ToUpper();

                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter your customer id");
                        string check1=Console.ReadLine();
                        bool flag=false;
                        foreach (CustomerDetail cd in customerList)
                            {
                                if(check1==cd.CustomerId)
                                {
                                    flag=true;
                                    Console.WriteLine("1-Deposit\n2-Withdraw\n3-balance check\n4-exit");
                                    int ch2=int.Parse(Console.ReadLine());
                                    switch (ch2)
                                    {
                                        case 1:
                                        {
                                            Console.WriteLine("Enter money to deposite:");
                                            double money=double.Parse(Console.ReadLine());
                                            cd.Deposite(money);
                                            Console.WriteLine("Now youe balance is"+cd.Balance);
                                            break;
                                        }
                                        case 2:
                                        {
                                            Console.WriteLine("Enter money to Withdraw:");
                                            double money=double.Parse(Console.ReadLine());
                                            double withdrawMoney=cd.Withdraw(money);
                                            if(withdrawMoney>0)
                                            {
                                                Console.WriteLine("Now your baklance is"+cd.Balance);

                                            }
                                            else{
                                                Console.WriteLine("Insufficient balance");
                                            }
                                            
                                            break;
                                            
                                        }
                                        case 3:
                                        {
                                            Console.WriteLine("------------------CUSTOMER DETAILS---------------");
                                            Console.WriteLine($"name:{cd.CustomerName}\n id:{cd.CustomerId}\n balance:{cd.Balance}\nGender:{cd.Gender}\n ph.no:{cd.Phone}\nmailid:{cd.MailId}\n dob:{cd.DOB}");
                                            break;

                                        }
                                        case 4:
                                        {
                                            flag=true;
                                            Console.WriteLine("Thank you!!");
                                            break;
                                        }
                                    }
                                   
                                }
                            }
                        if(flag!=true)
                        {
                            Console.WriteLine("!Customer id is wrong pls try again!!!");
                        }
                    //break;
                    Console.WriteLine("Do u want to continue Yes/no");
                    option = Console.ReadLine();        


                    }
                    break;
                case 3:
                {
                    Console.WriteLine("Thank you");
                    break;

                }
                
                
            }



        } while (option == "YES");

        

    }
}
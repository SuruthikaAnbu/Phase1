using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
namespace EbBillCalculation;

class Program{
    public static void Main(string[] args)
    {
        List<EbBill> customerList = new List<EbBill>();
        bool flag=true;
        do{
            Console.WriteLine("----------Select Number----------\n1.Registration\n2.Login\n3.Exit");
            int choice1=int.Parse(Console.ReadLine());
            switch(choice1)
            {
                case 1:
                {
                    EbBill object1=new EbBill();
                    Console.Write("Enter your user name : ");
                    object1.UserName=Console.ReadLine();
                    Console.Write("Enter your phone no : ");
                    object1.PhoneNumber=double.Parse(Console.ReadLine());
                    Console.Write("Enter your Mail ID : ");
                    object1.MailID=Console.ReadLine();
                    Console.Write("Enter your unit used :");
                    object1.UnitsUSed=int.Parse(Console.ReadLine());
                    customerList.Add(object1);
                    Console.WriteLine("\n\n----You have registered successfully----\n and your Meter ID is : "+object1.MeterId);
                    Console.WriteLine("Do you want to continue? true or false");
                    flag=bool.Parse(Console.ReadLine());
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Enter your meter id:");
                    string meterIdChoice=Console.ReadLine();
                    int count=0;
                    foreach(EbBill checker in customerList)
                    {
                        if(meterIdChoice==checker.MeterId)
                        {
                            count++;
                            Console.WriteLine("Choose 1\n1.Calculate amount\n2.Display user detail\n3.Exit");
                            int choice2=int.Parse(Console.ReadLine());
                            switch(choice2)
                            {
                                case 1:
                                {
                                    checker.UnitDeatils();

                                    break;
                                }
                                case 2:
                                {
                                    Console.WriteLine($"METER ID : {checker.MeterId}\nUSER NAME : {checker.UserName}\n PHONE NO : {checker.PhoneNumber}\nMAIL ID:{checker.MailID}");
                                    break;
                                }
                                case 3:
                                {
                                    Console.WriteLine("Thank you");
                                    break;
                                }
                            }

                        }

                    }
                    if(count==0)
                    {
                        Console.WriteLine("Invalid Meter Id");
                        break;

                    }
                    break;
                }
                case 3:
                {
                    Console.WriteLine("Thank you");
                    break;
                }
                default:
                {
                    break;
                }
            }
            

        }while(flag);
        /*Properties - Meter ID -(EB1001), Username, Phone number, Mail id, Units Used =0
Methods – Calculate Amount
Execution Sequence
Design main menu that ask user 1. Registration or 2. Login 3. Exit
1.	If 1. Registration selected ask Username, Phone number, Mail id, create object, show Meter ID and store it to list
2.	If 3. Selected exit from application
3.	If 2. Login selected ask Meter id 
•	verify Meter id
o	If no match found then tell the user "Invalid Meter ID "
o	If match found then display the sub menu 
1. Calculate Amount 2. Display user Details 2. Exit
			a. if 1. Selected ask user to enter unit details and based on unit entered calculate Rs. 5 / Unit and Display Bill - ID, User Name and unit and Amount
			b. if 2. Selected display the User details - Meter ID -(EB1001), Username, Phone number, Mail id
			if 3. Pressed exit from submenu and show main menu.
*/


    }
}
using System;
using System.Data;
namespace DateTimeAssignment;
class Program{
    public static void Main(string[] args)
    {
        DateTime dob=new DateTime(2021,8,10,10,40,32);
        Console.WriteLine(dob.Year);
        Console.WriteLine(dob.Month);
        Console.WriteLine(dob.Day);
        Console.WriteLine(dob.Hour);
        Console.WriteLine(dob.Minute);
        Console.WriteLine(dob.Second);
        //Console.WriteLine(dob.)
        string temp1=dob.ToString("dd/MM/yyyy hh:mm:ss tt");
        string[] dob1=temp1.Split('/',' ',':');
        Console.WriteLine("-------rev----");
        for(int i=dob1.Length-1;i>=0;i--)
        {
            Console.Write(dob1[i]+" ");

        }
        Console.Write("Enter date in the format of yyyy/mm/dd hh:mm:ss tt");
        DateTime finalDate=DateTime.ParseExact(Console.ReadLine(),"yyyy/MM/dd hh:mm:ss tt",null);
        Console.WriteLine(finalDate.Year);
        Console.WriteLine(finalDate.Month);
        Console.WriteLine(finalDate.Day);
        
    }
}
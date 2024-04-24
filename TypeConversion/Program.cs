using System;
namespace TypeConversion;
class Program{
    public static void Main(string[] args)
    {
        Console.Write("Enter your name:");
        string name=Console.ReadLine();
        Console.Write("Enter age:");
        int age=int.Parse(Console.ReadLine());
        Console.Write("Enter the mark of subject1:");
        float sub1=float.Parse(Console.ReadLine());
        Console.Write("Enter the mark of subject2:");
        float sub2=float.Parse(Console.ReadLine());
        Console.Write("Enter the mark of subject3:");
        float sub3=float.Parse(Console.ReadLine());
        Console.Write("Enter Grade:");
        char grade=char.Parse(Console.ReadLine());
        Console.Write("Enter Mobile number:");
        long ph=long.Parse(Console.ReadLine());
        Console.Write("Enter Mail id:");
        string mail=Console.ReadLine();
        float total=sub1+sub2+sub3;
        float avg=total/3;
        Console.WriteLine("Trainee details are:");
        Console.WriteLine("Name: "+name);
        Console.WriteLine("Age: "+age);
        Console.WriteLine("Mobile:"+ph);
        Console.WriteLine("Marks1:"+sub1);
        Console.WriteLine("Marks2:"+sub2);
        Console.WriteLine("Mark3: "+sub3);
        Console.WriteLine("Total :"+total);
        Console.WriteLine("Average"+avg);
        Console.WriteLine("Grade : "+grade);
        Console.WriteLine("Mail : "+mail);
    }
}
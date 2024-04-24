using System;
using System.Reflection.PortableExecutable;
namespace SwitchCase;
class Program{
    public static void Main(string[] args)
    {
        Console.Write("enter num1:");
        int num1=Convert.ToInt32(Console.ReadLine());
        Console.Write("enter num1:");
        int num2=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter operator: ");
        char ope=Char.Parse(Console.ReadLine());
        switch(ope)
        {
            case '+':
            {
                Console.WriteLine(num1+num2);
                break;
            }
            case '-':
            {
                Console.WriteLine(num1-num2);
                break;
            }
            case '*':
            {
                Console.WriteLine(num1*num2);
                break;
            }
            case '/':
            {
                Console.WriteLine(num1/num2);
                break;
            }
            case '%':
            {
                Console.WriteLine(num1%num2);
                break;
            }
            default:
            {
                Console.WriteLine("Wrong operator");
                break;
            }
        }

    }
}
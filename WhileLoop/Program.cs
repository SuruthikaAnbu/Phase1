using System;
namespace WhileLoop;
class Program{
    public static void Main(string[] args)
    {
        int number=0;
        while(number<=25)
        {
            if(number%2==0)
            {
                Console.WriteLine(number);
            }
            number++;
        }

        Console.WriteLine("Enter the num:");
        int a=0;
        
        bool number1=int.TryParse(Console.ReadLine(),out a);
        while(!number1)
        {
            Console.Write("Invalid input format. Please enter the input in number format");
            number1=int.TryParse(Console.ReadLine(),out a);
        }
        
        Console.WriteLine("Valid number");

        

    }

    
}

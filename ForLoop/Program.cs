using System;
namespace ForLoop;
class Progarm{
    public static void Main(string[] args)
    {
        Console.Write("Enter first number");
        int start=int.Parse(Console.ReadLine());
        Console.Write("Enter second number");
        int end=int.Parse(Console.ReadLine());
        int sum=0;
        for(int i=start;i<=end;i++)
        {
            int sqr=i*i;
            sum+=sqr;
    

        }
        Console.WriteLine(sum);
    }
}

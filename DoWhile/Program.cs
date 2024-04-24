using System;
namespace DoWhile;
class Program{
    public static void Main(string[] args)
    {
        
        string isValue;
        do{
            Console.WriteLine("Enter a number");
            int num=int.Parse(Console.ReadLine());
            if(num%2==0)
            {
                Console.WriteLine("even");
            }
            else{
                Console.WriteLine("odd");
            }
            Console.WriteLine("Do you want to continue? yes/no");
            isValue=Console.ReadLine();
            if (isValue!="yes" && isValue !="no")
            {
                Console.WriteLine("wrong input!! plese choose yes/no");
                isValue=(Console.ReadLine());
            }
        }while(isValue=="yes");
    }
}
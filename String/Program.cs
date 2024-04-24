using System;
namespace String;
class Program{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter input1");
        string str1=Console.ReadLine();
        Console.WriteLine("Enter input2");
        string str2=Console.ReadLine();
        string[] arr1=str1.Split(str2);
        int count=0;
        foreach(string i in arr1)
        {
            count=count+1;
        }
        Console.WriteLine(count-1);

        
    }
}

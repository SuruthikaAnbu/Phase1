using System;
using System.Threading;
namespace Array;
class Program{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the size of an array");
    
        string[] array1=new string[size];
        for(int i=0;i<size;i++)
        {
            Console.Write("Enter the name:");
            array1[i]=Console.ReadLine();
        }
        Console.WriteLine("----------Names in array-------");
        for(int i=0;i<size;i++)
        {
            Console.WriteLine(array1[i]);
        }
        Console.Write("Enter the name to search:");
        string name=Console.ReadLine();
        int count=0;
        for(int i=0;i<size;i++)
        {
            if(array1[i]==name)
            {
                Console.WriteLine("The name is present in array and the index is: "+i);
                count++;
            }
            
        }
        if(count==0)
            {
                Console.WriteLine("name is not present in array");
            }
        int count2=0;
        foreach(string i in array1)
        {
            if(i==name)
            {
                Console.WriteLine("The name is present in array ");
                count2++;
                break;

            }
            

        }
        if(count2==0)
            {
                Console.WriteLine("name is not present in array");
            }

    }
}

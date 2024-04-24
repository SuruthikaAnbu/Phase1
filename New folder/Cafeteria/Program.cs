using System;
namespace Cafeteria;
class Program{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        Operation.DefaultData();
        FileHandling.WriteToCSV();
        Operation.MainMenu();
    }
}
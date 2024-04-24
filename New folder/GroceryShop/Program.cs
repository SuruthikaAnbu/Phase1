using System;
using GroceryShop;
namespace GrocerShop;
class Program{
    public static void Main(string[] args)
    {
        FileHandling.CreateFolder();
        FileHandling.ReadFromCSV();
        //Opration.DefaultData();
        Opration.MainMenu();
        FileHandling.WriteToCSV();
        
        
       
    }
}
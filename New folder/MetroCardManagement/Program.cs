using System;
namespace MetroCardManagement;
class Program{
    public static void Main(string[] args)
    {
        FileHandling.CreateFile();
        FileHandling.ReadFromFile();
        //Operation.AddDefaultData();
        Operation.MainMenu();
        FileHandling.WriteToFile();
        
        
        
    }
}
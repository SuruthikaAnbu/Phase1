using System;
namespace MedicalShop;
class Program{
    public static void Main(string[] args)
    {
        FileHandling.CreateFile();
        //Opeartion.DefaultData();
        FileHandling.ReadFromFile();
        Opeartion.MainMenu();
        FileHandling.WriteToFile();
    }
}
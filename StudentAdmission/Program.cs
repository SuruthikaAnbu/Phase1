using System;
namespace StudentAdmission;
class Program
{
    public static void Main(string[] args)
    {
        //file handling
        FileHandling.Create();
        //Default data calling
        //Operations.AddDefaultData();
        FileHandling.ReadFromCSV();

        //Calling main menu
        Operations.MainMenu();
        //write in csv
        FileHandling.WriteToCSV();
    }
}

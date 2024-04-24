using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MetroCardManagement
{
    public static class FileHandling
    {
        //create file
        public static void CreateFile()
        {
            if(!Directory.Exists("MertroManagement"))
            {
                Console.WriteLine("creating...");
                Directory.CreateDirectory("MertroManagement");
            }
            if(!File.Exists("MertroManagement/PersonalDetails.csv"))
            {
                Console.WriteLine("creating file 1");
                File.Create("MertroManagement/PersonalDetails.csv").Close();
            }
            if(!File.Exists("MertroManagement/TicketFair.csv"))
            {
                Console.WriteLine("creating file 2");
                File.Create("MertroManagement/TicketFair.csv").Close();
            }
            if(!File.Exists("MertroManagement/TravelDetails.csv"))
            {
                Console.WriteLine("creating file 3");
                File.Create("MertroManagement/TravelDetails.csv").Close();
            }
            if(!File.Exists("MertroManagement/UserDetails.csv"))
            {
                Console.WriteLine("creating file 4");
                File.Create("MertroManagement/UserDetails.csv").Close();
            }
        }
        //write to file 
        public static void WriteToFile()
        {
            //personal detail
            string[] personal=new string[Operation.personalList.Count];
            for(int i=0;i<Operation.personalList.Count;i++)
            {
                personal[i]=Operation.personalList[i].UserName+","+Operation.personalList[i].PhoneNumber;
            }
            //Console.WriteLine(personal);
            File.AppendAllLines("MertroManagement/PersonalDetails.csv",personal);

            //ticket fair list
            string[] ticket=new string[Operation.ticketFairList.Count];
            for(int i=0;i<Operation.ticketFairList.Count;i++)
            {
                ticket[i]=Operation.ticketFairList[i].TicketID+","+Operation.ticketFairList[i].FromLocation+","+Operation.ticketFairList[i].ToLocation+","+Operation.ticketFairList[i].TicketPrice;
            }
            File.AppendAllLines("MertroManagement/TicketFair.csv",ticket);

            //travel detail list
            string[] travel=new string[Operation.travelDetailList.Count];
            for(int i=0;i<Operation.travelDetailList.Count;i++)
            {
                travel[i]=Operation.travelDetailList[i].TravelID+","+Operation.travelDetailList[i].CardNumber+","+Operation.travelDetailList[i].FromLocation+","+Operation.travelDetailList[i].ToLocation+","+Operation.travelDetailList[i].Date.ToString("dd/MM/yyyy")+","+Operation.travelDetailList[i].TravelCost;
            }
            File.AppendAllLines("MertroManagement/TravelDetails.csv",travel);
            //user detail list
            string[] user=new string[Operation.userDetailsList.Count];
            for(int i=0;i<Operation.userDetailsList.Count;i++)
            {
                user[i]=Operation.userDetailsList[i].CardNumber+","+Operation.userDetailsList[i].UserName+","+Operation.userDetailsList[i].PhoneNumber+","+Operation.userDetailsList[i].Balance;
            }
            File.AppendAllLines("MertroManagement/userDetails.csv",user);

        }
        //read from file
        //ticket fair
        public static void ReadFromFile()
        {
            string[] ticket1=File.ReadAllLines("MertroManagement/PersonalDetails.csv");
            foreach(string ticket in ticket1)
            {
                TicketFair ticketobj=new TicketFair(ticket);
                Operation.ticketFairList.Add(ticketobj);
                //ticket1=TicketFair(string ticket1)
            }
            //travel detail
            string[] travels=File.ReadAllLines("MertroManagement/TravelDetails.csv");
            foreach(string travel in travels)
            {
                TravelDetails travelobj=new TravelDetails(travel);
                Operation.travelDetailList.Add(travelobj);
            }
            //user details
            string[] users=File.ReadAllLines("MertroManagement/userDetails.csv");
            foreach(string user in users)
            {
                UserDetails userObj=new UserDetails(user);
                Operation.userDetailsList.Add(userObj);
                //ticket1=TketFair(string ticket1)
            }
        }

    }
}
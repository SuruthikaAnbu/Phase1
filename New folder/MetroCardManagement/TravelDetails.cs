using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TravelDetails
    {
        private static int s_travelID=2000;
        public string TravelID { get; set; }
        public string CardNumber { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime Date { get; set; }
        public double TravelCost { get; set; }

        //constructor
        public TravelDetails(string cardNumber,string fromLocation, string toLocation,DateTime date,double travelCost)
        {
            s_travelID++;
            TravelID="TID"+s_travelID;
            CardNumber=cardNumber;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            Date=date;
            TravelCost=travelCost;

        }
        public TravelDetails(string values)
        {
            string[] value=values.Split(",");
            //s_travelID++;
            TravelID=value[0];
            s_travelID=int.Parse(value[0].Remove(0,3));
            CardNumber=value[1];
            FromLocation=value[2];
            ToLocation=value[3];
            Date=DateTime.ParseExact(value[4],"dd/MM/yyyy",null);
            TravelCost=double.Parse(value[5]);

        }
    }
}
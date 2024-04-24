using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TicketFair
    {
        private static int s_tiketID=3000;
        public string TicketID { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public double TicketPrice { get; set; }

        //constructor
        public TicketFair(string fromLocation,string toLocation,double ticketPrice)
        {
            s_tiketID++;
            TicketID="MR"+s_tiketID;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            TicketPrice=ticketPrice;
        }
        public TicketFair(string value)
        {
            string[] values=value.Split(",");
            TicketID=values[0];
            s_tiketID=int.Parse(values[0].Remove(0,1));
            FromLocation=values[1];
            ToLocation=values[2];
            TicketPrice=double.Parse(values[3]);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShop
{
    public enum BookingStatus{initiated,booked,cancelled}
    public class BookingDetails
    {
        private static int s_bookID=3000;
        public string BookID { get; set; }
        public string CustomerID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateOfBooking { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public BookingDetails(string customerID,double totalPrice,DateTime dateOfBooking,BookingStatus bookingStatus)
        {
            s_bookID++;
            BookID="BID"+s_bookID;
            CustomerID=customerID;
            TotalPrice=totalPrice;
            DateOfBooking=dateOfBooking;
            BookingStatus=bookingStatus;
        }
        public BookingDetails(string value)
        {
            string[] values=value.Split(",");
            BookID=values[0];
            s_bookID=int.Parse(values[0].Remove(0,3));
            CustomerID=values[1];
            TotalPrice=double.Parse(values[2]);
            DateOfBooking=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            BookingStatus=Enum.Parse<BookingStatus>(values[4]);
        }

    }
}
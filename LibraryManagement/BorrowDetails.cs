using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public enum Status{Borrowed,Returned}
    public class BorrowDetails
    {
        private static int s_borrowID=2000;
        public string BorrrowID { get; set; }
        public string BookID { get; set; }
        public string UserID { get; set; }
        public DateTime BorrowDate { get; set; }
        public int BookCount { get; set; }
        public Status Status { get; set; }
        public long PaidFineAmount { get; set; }

    
    public BorrowDetails(string bookId,string userId,DateTime borrowDate,int bookCount,Status status,long paidMoney)
    {
        s_borrowID++;
        BorrrowID="LB"+s_borrowID;
        BookID=bookId;
        UserID=userId;
        BorrowDate=borrowDate;
        BookCount=bookCount;
        Status=status;
        PaidFineAmount=paidMoney;

    }
    }
}
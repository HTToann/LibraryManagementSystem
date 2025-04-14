using System;

namespace DTOs
{
    public class HistoryBorrowDTO
    {
        public int ID { get; set; }
        public int DetailBorrowReturnBookID { get; set; }
        public int StatusID { get; set; }
        public DateTime BookReturnDate { get; set; }

        public string StatusName { get; set; }
    }
}

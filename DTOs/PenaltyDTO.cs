using System;

namespace DTOs
{
    public class PenaltyDTO
    {
        public int ID { get; set; }
        public int HistoryBorrowID { get; set; }
        public DateTime PenaltyDate { get; set; }
        public int NumberOfPenaltyDays { get; set; }
        public decimal FineAmount { get; set; }
        public bool Status { get; set; } // true = đã đóng
    }
}

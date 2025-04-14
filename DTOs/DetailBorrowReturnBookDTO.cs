namespace DTOs
{
    public class DetailBorrowReturnBookDTO
    {
        public int ID { get; set; }
        public int BorrowReturnBookID { get; set; }
        public int BookID { get; set; }
        public int Count { get; set; }

        public string BookName { get; set; }
    }
}

namespace DTOs
{
    public class BookAuthorDTO
    {
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public int BookID { get; set; }
        public string AuthorName { get; set; }   // NEW
        public string BookName { get; set; }     // NEW
    }
}

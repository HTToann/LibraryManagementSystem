namespace DTOs
{
    public class BookDTO
    {
        public int BookID { get; set; }
        public string CodeBook { get; set; }
        public string NameBook { get; set; }
        public int YearOfPublication { get; set; }
        public int Count { get; set; }
        public int CategoryID { get; set; }
        public int PublisherID { get; set; }
        public int SupplierID { get; set; }

        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
        public string SupplierName { get; set; }
    }
}

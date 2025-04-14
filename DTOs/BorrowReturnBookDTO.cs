using System;

namespace DTOs
{
    public class BorrowReturnBookDTO
    {
        public int ID { get; set; }
        public int ReaderID { get; set; }
        public int UserID { get; set; }
        public DateTime DateBorrow { get; set; }
        public DateTime DateReturn { get; set; }
        public int StatusID { get; set; }


        // Thông tin hiển thị thêm
        public string ReaderName { get; set; }  
        public string UserName { get; set; }
        public string StatusName { get; set; }
    }
}

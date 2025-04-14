using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class BorrowedBookInfoDTO
    {
        public int DetailID { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }

        public int Count { get; set; }
        public DateTime DateBorrow { get; set; }
        public DateTime DateReturn { get; set; }
        public int OverdueDays { get; set; } // tính nếu có
        public decimal FineAmount { get; set; } // tùy xử lý
    }

}

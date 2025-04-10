using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

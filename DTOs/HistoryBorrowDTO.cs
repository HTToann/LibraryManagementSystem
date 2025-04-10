using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class HistoryBorrowDTO
    {
        public int ID { get; set; }
        public int DetailBorrowReturnBookID { get; set; }
        public int StatusID { get; set; }
        public DateTime BookReturnDate { get; set; }
    }
}

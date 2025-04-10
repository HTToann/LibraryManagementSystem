using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DetailBorrowReturnBookDTO
    {
        public int ID { get; set; }
        public int BorrowReturnBookID { get; set; }
        public int BookID { get; set; }
        public int Count { get; set; }
    }
}

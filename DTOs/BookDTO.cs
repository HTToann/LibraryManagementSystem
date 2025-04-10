using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
<<<<<<<< HEAD:DTOs/StatsDTO/TopBookDTO.cs
    public class TopBookDTO
    {
        public string BookName { get; set; }
        public int BorrowCount { get; set; }
========
    public class BorrowPerMonthDTO
    {
        public int Month { get; set; }
        public int TotalBorrows { get; set; }
<<<<<<< HEAD
>>>>>>>> 871a8b6516b92655cf4785302f34199e02192535:DTOs/StatsDTO/BorrowPerMonthDTO.cs
=======
>>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2:DTOs/StatsDTO/BorrowPerMonthDTO.cs
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
    }
}

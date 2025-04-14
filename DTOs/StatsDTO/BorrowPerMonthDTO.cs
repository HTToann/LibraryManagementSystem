using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
<<<<<<<< HEAD:DTOs/StatsDTO/BorrowPerMonthDTO.cs
    public class BorrowPerMonthDTO
    {
        public int Month { get; set; }
        public int TotalBorrows { get; set; }
========
    public class TopBookDTO
    {
        public string BookName { get; set; }
        public int BorrowCount { get; set; }
>>>>>>>> tomerge:DTOs/StatsDTO/TopBookDTO.cs
    }
}

using DataLayer;
using DTOs;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class StatsService
    {
        private StatsRepository _repo = new StatsRepository();
        public List<BorrowPerMonthDTO> GetBorrowCountPerMonth()
        {
            return _repo.GetBorrowCountPerMonth();
        }

        public List<TopBookDTO> GetTop5BorrowedBooks()
        {
            return _repo.GetTop5BorrowedBooks();
        }
        public ReturnRateDTO GetReturnRate()
        {
            return _repo.GetReturnRate();
        }
        public List<MonthlyPenaltyDTO> GetTotalPenaltyPerMonth()
        {
            return _repo.GetTotalPenaltyPerMonth();
        }
    }
}

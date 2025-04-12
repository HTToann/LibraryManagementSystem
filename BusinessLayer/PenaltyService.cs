using System;
using System.Collections.Generic;
using DTOs;
using DataLayer;
using System.Linq;

namespace BusinessLayer
{
    public class PenaltyService
    {
        private readonly PenaltyRepository _repo;
        public PenaltyService()
        {
            _repo = new PenaltyRepository();
        }

        public List<PenaltyDTO> GetAllPenalties()
        {
            return _repo.GetAllPenalties();
        }

        public bool InsertPenalty(PenaltyDTO dto)
        {
            return _repo.Insert(dto);
        }

        public bool UpdatePenalty(PenaltyDTO dto)
        {
            return _repo.Update(dto);
        }

        public bool DeletePenalty(int id)
        {
            return _repo.Delete(id);
        }

        public List<PenaltyDTO> GetPenaltiesByHistoryBorrowID(int historyBorrowID)
        {
            return _repo.GetPennaltyByHistoryBorrowID(historyBorrowID);
        }
        // Optional: Tính toán tổng tiền phạt cho HistoryBorrowID
        public decimal GetTotalFineByHistoryBorrowID(int historyBorrowID)
        {
            var penalties = _repo.GetPennaltyByHistoryBorrowID(historyBorrowID);
            return penalties.Sum(p => p.FineAmount);
        }
    }
}

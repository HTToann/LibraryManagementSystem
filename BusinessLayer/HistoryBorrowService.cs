using DataLayer;
using DTOs;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class HistoryBorrowService
    {
        private HistoryBorrowRepository _repo;
        public HistoryBorrowService()
        {
            _repo = new HistoryBorrowRepository();
        }
        public List<HistoryBorrowDTO> GetAllHistory()
        {
            return _repo.GetAllHistory();
        }
        public bool Insert(HistoryBorrowDTO history)
        {
            return _repo.Insert(history);
        }
        public bool Update(HistoryBorrowDTO history)
        {
            return _repo.Update(history);
        }
        public bool Delete(int historyID)
        {
            return _repo.Delete(historyID);
        }
        public List<BookConditionStatusDTO> GetAllStatuses()
        {
            return _repo.GetAllStatuses();
        }
        public List<HistoryBorrowDTO> GetHistoryByDetailID(int id)
        {
            return _repo.GetByDetailBorrowReturnID(id);
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
        public int InsertAndGetId(HistoryBorrowDTO dto)
        {
            return _repo.InsertAndGetId(dto);
        }
<<<<<<< HEAD
=======
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
    }
}

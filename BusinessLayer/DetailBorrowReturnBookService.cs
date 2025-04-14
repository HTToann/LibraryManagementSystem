using DataLayer;
using DTOs;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class DetailBorrowReturnBookService
    {
        private DetailBorrowReturnBookRepository _repo;
        public DetailBorrowReturnBookService()
        {
            _repo = new DetailBorrowReturnBookRepository();
        }
        public List<DetailBorrowReturnBookDTO> GetAllDetails()
        {
            return _repo.GetAllDetails();
        }
        public bool Insert(DetailBorrowReturnBookDTO detail)
        {
            return _repo.Insert(detail);
        }
        public bool Update(DetailBorrowReturnBookDTO detail)
        {
            return _repo.Update(detail);
        }
        public bool Delete(int detailID)
        {
            return _repo.Delete(detailID);
        }
        public List<DetailBorrowReturnBookDTO> GetDetailsByBorrowReturnID(int id)
        {
            return _repo.GetDetailsByBorrowReturnID(id);
        }
    }
}

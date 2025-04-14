    using DataLayer;
using DTOs;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class BorrowReturnBookService
    {
        private BorrowReturnBookRepository _repo;
        public BorrowReturnBookService()
        {
            _repo = new BorrowReturnBookRepository();
        }
        public List<BorrowReturnBookDTO> GetAllBorrowReturnBooks()
        {

            return _repo.GetAllBorrowReturnBooks();
        }
        public bool Insert(BorrowReturnBookDTO borrowReturnBook)
        {
            return _repo.Insert(borrowReturnBook);
        }
        public bool Update(BorrowReturnBookDTO borrowReturnBook)
        {
            return _repo.Update(borrowReturnBook);
        }
        public bool Delete(int borrowReturnBookId)
        {
            return _repo.Delete(borrowReturnBookId);
        }
        public List<BorrowReturnBookDTO> GetBorrowReturnByReaderName(string kw)
        {
            return _repo.SearchBorrowReturnByReaderName(kw);
        }
        public List<BorrowReturnBookDTO> GetBorrowReturnByReaderID(int id)
        {
            return _repo.SearchBorrowReturnByReaderId(id);
        }
        public List<BorrowStatusDTO> GetAllStatuses()
        {
            return _repo.GetAllStatus();
        }
        public int InsertAndGetId(BorrowReturnBookDTO dto)
        {
            return _repo.InsertAndGetId(dto);
        }
        public List<BorrowedBookInfoDTO> GetBorrowedBooksByReader(int readerId)
        {
            return _repo.GetBorrowedBooksByReader(readerId);
        }
        public void MarkAsReturnedByDetailBookIDs(List<int> bookIds)
        {
            _repo.MarkAsReturnedByDetailIDs(bookIds);
        }

    }
}

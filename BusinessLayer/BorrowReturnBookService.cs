<<<<<<< HEAD
<<<<<<< HEAD
﻿    using DataLayer;
=======
<<<<<<< HEAD
=======
>>>>>>> 057b4d8b3eaae73966fe867ed2d53714f6127a6f
<<<<<<< HEAD
﻿    using DataLayer;
=======
<<<<<<< HEAD
﻿    using DataLayer;
=======
﻿using DataLayer;
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
﻿using DataLayer;
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
<<<<<<< HEAD
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
=======
>>>>>>> 057b4d8b3eaae73966fe867ed2d53714f6127a6f
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
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> 057b4d8b3eaae73966fe867ed2d53714f6127a6f
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
<<<<<<< HEAD
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
=======
>>>>>>> 057b4d8b3eaae73966fe867ed2d53714f6127a6f
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

<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 057b4d8b3eaae73966fe867ed2d53714f6127a6f
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
<<<<<<< HEAD
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
=======
>>>>>>> 057b4d8b3eaae73966fe867ed2d53714f6127a6f
    }
}

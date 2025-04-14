using DataLayer;
using DTOs;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class ReaderService
    {
        private ReaderRepository _repo;
        public ReaderService()
        {
            _repo = new ReaderRepository();
        }
        public List<ReaderDTO> GetReaders()
        {
            return _repo.GetAllReaders();
        }
        // 2. Thêm bạn đọc mới
        public bool InsertReader(ReaderDTO reader)
        {
            if (string.IsNullOrWhiteSpace(reader.FirstName) || string.IsNullOrWhiteSpace(reader.LastName))
                return false;

            return _repo.InsertReader(reader);
        }
        // 3. Cập nhật thông tin bạn đọc
        public bool UpdateReader(ReaderDTO reader)
        {
            if (reader.ReaderID <= 0)
                return false;

            return _repo.UpdateReader(reader);
        }
        // 4. Xoá bạn đọc
        public bool DeleteReader(int readerID)
        {
            if (readerID <= 0)
                return false;

            return _repo.DeleteReader(readerID);
        }

        // 5. Tìm kiếm bạn đọc theo tên
        public List<ReaderDTO> SearchReaderByName(string keyword)
        {
            return _repo.SearchByName(keyword);
        }
        public ReaderDTO SearchReaderById(int id)
        {
            return _repo.SearchById(id);
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
        public ReaderDTO FindByGmailOrPhone(string gmail, string phone)
        {
            return _repo.FindByGmailOrPhone(gmail, phone);
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

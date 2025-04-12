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
    }
}

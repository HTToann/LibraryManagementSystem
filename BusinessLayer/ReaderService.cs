using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DTOs;
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
        public bool AddReader(ReaderDTO reader)
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
        public List<ReaderDTO> FindReaders(string keyword)
        {
            return _repo.SearchByName(keyword);
        }
    }
}

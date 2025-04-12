using DataLayer;
using DTOs;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class BookAuthorService
    {
        private BookAuthorRepository _repo;
        public BookAuthorService()
        {
            _repo = new BookAuthorRepository();
        }
        public List<BookAuthorDTO> GetAllBookAuthors()
        {

            return _repo.GetAllBookAuthors();
        }
        public bool InsertBookAuthor(BookAuthorDTO bookAuthor)
        {
            return _repo.InsertBookAuthor(bookAuthor);
        }
        public bool UpdateBookAuthor(BookAuthorDTO bookAuthor)
        {
            return _repo.UpdateBookAuthor(bookAuthor);
        }
        public bool DeleteBookAuthor(int bookAuthorId)
        {
            return _repo.DeleteBookAuthor(bookAuthorId);
        }
        public List<BookAuthorDTO> GetBookAuthorByAuthorName(string kw)
        {
            return _repo.SearchBookAuthorByAuthorName(kw);
        }
        public List<BookAuthorDTO> GetBookAuthorByBookName(string kw)
        {
            return _repo.SearchBookAuthorByBookName(kw);
        }
        public BookAuthorDTO GetBookAuthorById(int id)
        {
            return _repo.SearchBookAuthorById(id);
        }
    }
}

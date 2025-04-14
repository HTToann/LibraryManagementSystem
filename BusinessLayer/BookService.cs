using DataLayer;
using DTOs;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class BookService
    {
        private BookRepository _repo;
        public BookService()
        {
            _repo = new BookRepository();
        }
        public List<BookDTO> GetAllBooks()
        {

            return _repo.GetAllBooks();
        }
        public bool InsertBook(BookDTO book)
        {
            return _repo.InsertBook(book);
        }
        public bool UpdateBook(BookDTO book)
        {
            return _repo.UpdateBook(book);
        }
        public bool DeleteBook(int bookId)
        {
            return _repo.DeleteBook(bookId);
        }
        public List<BookDTO> GetBookByName(string kw)
        {
            return _repo.SearchBookByName(kw);
        }
        public BookDTO GetBookById(int id)
        {
            return _repo.SearchBookById(id);
        }
<<<<<<< HEAD
        public void DecreaseStock(int bookId, int count)
        {
            _repo.DecreaseStock(bookId, count);
        }
        public void IncreaseStock(int bookId, int count)
        {
            _repo.IncreaseStock(bookId, count);
        }
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
    }
}

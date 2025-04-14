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
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
        public void DecreaseStock(int bookId, int count)
        {
            _repo.DecreaseStock(bookId, count);
        }
        public void IncreaseStock(int bookId, int count)
        {
            _repo.IncreaseStock(bookId, count);
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
    }
}

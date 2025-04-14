using DataLayer;
using DTOs;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class AuthorService
    {
        private AuthorRepository _repo;
        public AuthorService()
        {
            _repo = new AuthorRepository();
        }
        public List<AuthorDTO> GetAllAuthors()
        {

            return _repo.GetAllAuthors();
        }
        public bool InsertAuthor(AuthorDTO author)
        {
            return _repo.InsertAuthor(author);
        }
        public bool UpdateAuthor(AuthorDTO author)
        {
            return _repo.UpdateAuthor(author);
        }
        public bool DeleteAuthor(int authorId)
        {
            return _repo.DeleteAuthor(authorId);
        }
        public List<AuthorDTO> GetAuthorByName(string kw)
        {
            return _repo.SearchAuthorByName(kw);
        }
        public AuthorDTO GetAuthorById(int id)
        {
            return _repo.SearchAuthorById(id);
        }
    }
}

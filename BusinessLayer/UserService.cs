using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DTOs;
using Shared;
namespace BusinessLayer
{
    public class UserService
    {
        private readonly UserRepository _repo = new UserRepository();
        public bool Login(string username, string password)
        {
            var user = _repo.GetUserByUsername(username);
            if (user == null) return false;
            string hashedInput = HashPasswordHelper.HashPassword(password);
            return user.Password == hashedInput;
        }
        public bool Register(UserDTO user)
        {
            var existing = _repo.GetUserByUsername(user.Username);
            if (existing != null) return false; // Username đã tồn tại
            user.Password = HashPasswordHelper.HashPassword(user.Password);
            return _repo.AddUser(user);
        }

        public UserDTO GetUserByUsername(string username)
        {
            return _repo.GetUserByUsername(username);
        }
    }

}

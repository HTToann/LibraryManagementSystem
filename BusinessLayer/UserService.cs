using DataLayer;
using DTOs;
using Shared;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class UserService
    {
        private readonly UserRepository _repo = new UserRepository();
        public UserDTO Authenticate(string username, string password)
        {
            var user = _repo.Authenticate(username);
            if (user == null) return null;
            string hashedInput = HashPasswordHelper.HashPassword(password);
            return user.Password == hashedInput ? user : null;
        }
        public bool Register(UserDTO user)
        {
            var existing = _repo.GetUserByUsername(user.Username);
            if (existing != null) return false; // Username đã tồn tại
            user.Password = HashPasswordHelper.HashPassword(user.Password);
            return _repo.InsertUser(user);
        }
        public List<UserDTO> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }
        public bool UpdateUser(UserDTO user)
        {
            return _repo.UpdateUser(user);
        }
        public bool DeleteUser(int userId)
        {
            return _repo.DeleteUser(userId);
        }
        public List<UserRoleDTO> GellAllRoles()
        {
            return _repo.GetAllRoles();
        }
        public UserDTO GetUserByUsername(string username)
        {
            return _repo.GetUserByUsername(username);
        }
        public UserDTO GetUserByUserId(int userId)
        {
            return _repo.GetUserByID(userId);
        }
    }

}

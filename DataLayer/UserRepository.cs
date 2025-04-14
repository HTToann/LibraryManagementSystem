using DTOs;
using Shared;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace DataLayer
{
    public class UserRepository
    {
        public UserDTO Authenticate(string username)
        {
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();
                var query = @"
                            SELECT u.*, r.roleName 
                            FROM [User] u
                            JOIN UserRole r ON u.roleID = r.roleID
<<<<<<< HEAD
                            WHERE u.username=@username COLLATE SQL_Latin1_General_CP1_CS_AS" // Xóa Collate để không còn phân biệt chữ hoa và thường nữa
=======
<<<<<<< HEAD
                            WHERE u.username=@username COLLATE SQL_Latin1_General_CP1_CS_AS" // Xóa Collate để không còn phân biệt chữ hoa và thường nữa
=======
                            WHERE u.username=@username"
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                ;
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserDTO
                        {
                            UserID = (int)reader["userID"],
                            FirstName = reader["firstName"].ToString(),
                            LastName = reader["lastName"].ToString(),
                            Username = reader["username"].ToString(),
<<<<<<< HEAD
                            Password=reader["password"].ToString(),
=======
<<<<<<< HEAD
                            Password=reader["password"].ToString(),
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                            Gmail = reader["gmail"].ToString(),
                            Address = reader["address"].ToString(),
                            Phone = reader["phone"].ToString(),
                            RoleID = (int)reader["roleID"],
                            RoleName = reader["roleName"].ToString() // 👉 lấy tên vai trò
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                        };
                    }
                }
            }
            return null;

        }
        public UserDTO GetUserByUsername(string username)
        {
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();
                var query = @"
                            SELECT u.*, r.roleName 
                            FROM [User] u
                            JOIN UserRole r ON u.roleID = r.roleID
                            WHERE u.username=@username"
                ;
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserDTO
                        {
                            UserID = (int)reader["userID"],
                            FirstName = reader["firstName"].ToString(),
                            LastName = reader["lastName"].ToString(),
                            Username = reader["username"].ToString(),
                            Gmail = reader["gmail"].ToString(),
                            Address = reader["address"].ToString(),
                            Phone = reader["phone"].ToString(),
                            RoleID = (int)reader["roleID"],
                            RoleName = reader["roleName"].ToString() // 👉 lấy tên vai trò
<<<<<<< HEAD
=======
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                        };
                    }
                }
            }
            return null;
        }
        public UserDTO GetUserByID(int id)
        {
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();
                var query = @"
                            SELECT u.*, r.roleName 
                            FROM [User] u
                            JOIN UserRole r ON u.roleID = r.roleID
                            WHERE u.userID=@id"                 
                ;
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserDTO
                        {
                            UserID = (int)reader["userID"],
                            FirstName = reader["firstName"].ToString(),
                            LastName = reader["lastName"].ToString(),
                            Username = reader["username"].ToString(),
                            Gmail = reader["gmail"].ToString(),
                            Address = reader["address"].ToString(),
                            Phone = reader["phone"].ToString(),
                            RoleID = (int)reader["roleID"],
                            RoleName = reader["roleName"].ToString() // 👉 lấy tên vai trò
                        };
                    }
                }
            }
            return null;
        }
        public List<UserRoleDTO> GetAllRoles()
        {
            List<UserRoleDTO> roles = new List<UserRoleDTO>();
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserRole", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(new UserRoleDTO
                    {
                        RoleID = (int)reader["roleID"],
                        RoleName = reader["roleName"].ToString()
                    });
                }
            }
            return roles;
        }
        public List<UserDTO> GetAllUsers()
        {
            var list = new List<UserDTO>();
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();
                var query = @"
                            SELECT u.*, r.roleName 
                            FROM [User] u
                            JOIN UserRole r ON u.roleID = r.roleID";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserDTO
                        {
                            UserID = (int)reader["userID"],
                            FirstName = reader["firstName"].ToString(),
                            LastName = reader["lastName"].ToString(),
                            Username = reader["username"].ToString(),
                            Gmail = reader["gmail"].ToString(),
                            Address = reader["address"].ToString(),
                            Phone = reader["phone"].ToString(),
                            RoleID = (int)reader["roleID"],
                            RoleName = reader["roleName"].ToString() // 👉 lấy tên vai trò
                        });
                    }
                }
            }
            return list;
        }

        public bool InsertUser(UserDTO user)
        {
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"INSERT INTO [User](firstName, lastName, username, password, gmail, address, phone, roleID)
                                           VALUES (@firstName, @lastName, @username, @password, @gmail, @address, @phone, @roleID)", conn);

                cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                cmd.Parameters.AddWithValue("@lastName", user.LastName);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@gmail", user.Gmail);
                cmd.Parameters.AddWithValue("@address", user.Address);
                cmd.Parameters.AddWithValue("@phone", user.Phone);
                cmd.Parameters.AddWithValue("@roleID", user.RoleID);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool UpdateUser(UserDTO user)
        {
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                        UPDATE [User]
                        SET firstName=@firstName,
                            lastName=@lastName,
                            username=@username,
                            gmail=@gmail,
                            address=@address,
                            phone=@phone,
                            roleID=@roleID
                        WHERE userID=@userID", conn);
                cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                cmd.Parameters.AddWithValue("@lastName", user.LastName);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@gmail", user.Gmail);
                cmd.Parameters.AddWithValue("@address", user.Address);
                cmd.Parameters.AddWithValue("@phone", user.Phone);
                cmd.Parameters.AddWithValue("@roleID", user.RoleID);
                cmd.Parameters.AddWithValue("@userID", user.UserID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool DeleteUser(int userId)
        {
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM [User] WHERE userID = @userID", conn);
                cmd.Parameters.AddWithValue("@userID", userId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        private UserDTO ReadUser(SqlDataReader reader)
        {
            return new UserDTO
            {
                UserID = (int)reader["userID"],
                FirstName = reader["firstName"].ToString(),
                LastName = reader["lastName"].ToString(),
                Username = reader["username"].ToString(),
                Password = reader["password"].ToString(),
                Gmail = reader["gmail"].ToString(),
                Address = reader["address"].ToString(),
                Phone = reader["phone"].ToString(),
                RoleID = (int)reader["roleID"]
            };
        }
    }
}

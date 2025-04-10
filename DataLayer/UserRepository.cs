using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Shared;
namespace DataLayer
{
    public class UserRepository
    {
        public UserDTO GetUserByUsername(string username)
        {
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM [USER] WHERE username=@username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                using (var reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
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
            return null;
        }
        public bool AddUser(UserDTO user)
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
    }
}

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
    public class AuthorRepository
    {
        public List<AuthorDTO> GetAllAuthors()
        {
            var list = new List<AuthorDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Author";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new AuthorDTO
                    {
                        AuthorID = (int)reader["authorID"],
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        DateOfBirth = reader["dateOfBirth"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["dateOfBirth"])
                    });
                }
            }
            return list;
        }

        public bool InsertAuthor(AuthorDTO author)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"INSERT INTO Author (firstName, lastName, dateOfBirth)
                         VALUES (@FirstName, @LastName, @DOB)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", author.FirstName);
                cmd.Parameters.AddWithValue("@LastName", author.LastName);
                cmd.Parameters.AddWithValue("@DOB", author.DateOfBirth);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateAuthor(AuthorDTO author)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"UPDATE Author SET 
                         firstName = @FirstName,
                         lastName = @LastName,
                         dateOfBirth = @DOB
                         WHERE authorID = @AuthorID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AuthorID", author.AuthorID);
                cmd.Parameters.AddWithValue("@FirstName", author.FirstName);
                cmd.Parameters.AddWithValue("@LastName", author.LastName);
                cmd.Parameters.AddWithValue("@DOB", author.DateOfBirth);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteAuthor(int authorID)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "DELETE FROM Author WHERE authorID = @AuthorID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AuthorID", authorID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<AuthorDTO> SearchAuthorByName(string keyword)
        {
            var list = new List<AuthorDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Author WHERE firstName LIKE @Keyword OR lastName LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new AuthorDTO
                    {
                        AuthorID = (int)reader["authorID"],
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["dateOfBirth"])
                    });
                }
            }
            return list;
        }

        public AuthorDTO SearchAuthorById(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Author WHERE authorID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new AuthorDTO
                    {
                        AuthorID = (int)reader["authorID"],
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["dateOfBirth"])
                    };
                }
            }
            return null;
        }

    }
}

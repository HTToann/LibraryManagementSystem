using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTOs;
using Shared;

namespace DataLayer
{
    public class BookAuthorRepository
    {
        public List<BookAuthorDTO> GetAllBookAuthors()
        {
            var list = new List<BookAuthorDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
                    SELECT ba.id, ba.authorID, ba.bookID,
                           a.firstName + ' ' + a.lastName AS AuthorName,
                           b.nameBook AS BookName
                    FROM Book_Author ba
                    INNER JOIN Author a ON ba.authorID = a.authorID
                    INNER JOIN Book b ON ba.bookID = b.bookID";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BookAuthorDTO
                    {
                        ID = (int)reader["id"],
                        AuthorID = (int)reader["authorID"],
                        BookID = (int)reader["bookID"],
                        AuthorName = reader["AuthorName"].ToString(),
                        BookName = reader["BookName"].ToString()
                    });
                }
            }
            return list;
        }

        public bool InsertBookAuthor(BookAuthorDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"INSERT INTO Book_Author (authorID, bookID)
                                 VALUES (@AuthorID, @BookID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AuthorID", dto.AuthorID);
                cmd.Parameters.AddWithValue("@BookID", dto.BookID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool UpdateBookAuthor(BookAuthorDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"UPDATE Book_Author 
                         SET authorID = @AuthorID, bookID = @BookID
                         WHERE id = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", dto.ID);
                cmd.Parameters.AddWithValue("@AuthorID", dto.AuthorID);
                cmd.Parameters.AddWithValue("@BookID", dto.BookID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public bool DeleteBookAuthor(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "DELETE FROM Book_Author WHERE id = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<BookAuthorDTO> SearchBookAuthorByBookName(string keyword)
        {
            var list = new List<BookAuthorDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
            SELECT ba.id, ba.authorID, ba.bookID,
                   a.firstName + ' ' + a.lastName AS AuthorName,
                   b.nameBook AS BookName
            FROM Book_Author ba
            INNER JOIN Author a ON ba.authorID = a.authorID
            INNER JOIN Book b ON ba.bookID = b.bookID
            WHERE b.nameBook LIKE @Keyword";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BookAuthorDTO
                    {
                        ID = (int)reader["id"],
                        AuthorID = (int)reader["authorID"],
                        BookID = (int)reader["bookID"],
                        AuthorName = reader["AuthorName"].ToString(),
                        BookName = reader["BookName"].ToString()
                    });
                }
            }
            return list;
        }
        public List<BookAuthorDTO> SearchBookAuthorByAuthorName(string keyword)
        {
            var list = new List<BookAuthorDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
            SELECT ba.id, ba.authorID, ba.bookID,
                   a.firstName + ' ' + a.lastName AS AuthorName,
                   b.nameBook AS BookName
            FROM Book_Author ba
            INNER JOIN Author a ON ba.authorID = a.authorID
            INNER JOIN Book b ON ba.bookID = b.bookID
            WHERE a.firstName LIKE @Keyword OR a.lastName LIKE @Keyword";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BookAuthorDTO
                    {
                        ID = (int)reader["id"],
                        AuthorID = (int)reader["authorID"],
                        BookID = (int)reader["bookID"],
                        AuthorName = reader["AuthorName"].ToString(),
                        BookName = reader["BookName"].ToString()
                    });
                }
            }
            return list;
        }
        public BookAuthorDTO SearchBookAuthorById(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
            SELECT ba.id, ba.authorID, ba.bookID,
                   a.firstName + ' ' + a.lastName AS AuthorName,
                   b.nameBook AS BookName
            FROM Book_Author ba
            INNER JOIN Author a ON ba.authorID = a.authorID
            INNER JOIN Book b ON ba.bookID = b.bookID
            WHERE ba.id = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new BookAuthorDTO
                    {
                        ID = (int)reader["id"],
                        AuthorID = (int)reader["authorID"],
                        BookID = (int)reader["bookID"],
                        AuthorName = reader["AuthorName"].ToString(),
                        BookName = reader["BookName"].ToString()
                    };
                }
            }
            return null;
        }


    }
}

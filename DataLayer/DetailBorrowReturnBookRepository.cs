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
    public class DetailBorrowReturnBookRepository
    {

        public List<DetailBorrowReturnBookDTO> GetAllDetails()
        {
            var list = new List<DetailBorrowReturnBookDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
                    SELECT d.*,
                           b.nameBook AS BookName
                    FROM DetailBorrowReturnBook d
                    INNER JOIN Book b ON d.bookID = b.bookID";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new DetailBorrowReturnBookDTO
                    {
                        ID = (int)reader["ID"],
                        BorrowReturnBookID = (int)reader["BorrowReturnBookID"],
                        BookID = (int)reader["bookID"],
                        Count = (int)reader["count"],
                        BookName = reader["BookName"].ToString()
                    });
                }
            }
            return list;
        }

        public bool Insert(DetailBorrowReturnBookDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"INSERT INTO DetailBorrowReturnBook (borrowReturnBookID, bookID, count)
                                 VALUES (@BorrowReturnBookID, @BookID, @Count)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BorrowReturnBookID", dto.BorrowReturnBookID);
                cmd.Parameters.AddWithValue("@BookID", dto.BookID);
                cmd.Parameters.AddWithValue("@Count", dto.Count);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(DetailBorrowReturnBookDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"UPDATE DetailBorrowReturnBook SET 
                                 borrowReturnBookID = @BorrowReturnBookID,
                                 bookID = @BookID,
                                 count = @Count
                                 WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", dto.ID);
                cmd.Parameters.AddWithValue("@BorrowReturnBookID", dto.BorrowReturnBookID);
                cmd.Parameters.AddWithValue("@BookID", dto.BookID);
                cmd.Parameters.AddWithValue("@Count", dto.Count);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "DELETE FROM DetailBorrowReturnBook WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<DetailBorrowReturnBookDTO> GetDetailsByBorrowReturnID(int borrowReturnBookId)
        {
            var list = new List<DetailBorrowReturnBookDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
                    SELECT d.ID, d.BorrowReturnBookID, d.BookID, d.Count,
                           b.nameBook AS BookName
                    FROM DetailBorrowReturnBook d
                    INNER JOIN Book b ON d.BookID = b.BookID
                    WHERE d.BorrowReturnBookID = @BorrowReturnBookID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BorrowReturnBookID", borrowReturnBookId);

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new DetailBorrowReturnBookDTO
                    {
                        ID = (int)reader["ID"],
                        BorrowReturnBookID = (int)reader["BorrowReturnBookID"],
                        BookID = (int)reader["BookID"],
                        Count = (int)reader["Count"],
                        BookName = reader["BookName"].ToString()
                    });
                }
            }
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTOs;
using Shared;

namespace DataLayer
{
    public class HistoryBorrowRepository
    {
        public List<HistoryBorrowDTO> GetAllHistory()
        {
            var list = new List<HistoryBorrowDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
                    SELECT h.*,
                           s.statusName AS StatusName
                    FROM HistoryBorrow h
                    INNER JOIN BookConditionStatus s ON h.StatusID = s.StatusID";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new HistoryBorrowDTO
                    {
                        ID = (int)reader["ID"],
                        DetailBorrowReturnBookID = (int)reader["detailBorrowReturnBookID"],
                        StatusID = (int)reader["statusID"],
                        BookReturnDate = Convert.ToDateTime(reader["bookReturnDate"]),
                        StatusName = reader["StatusName"].ToString()
                    });
                }
            }
            return list;
        }
        public bool Insert(HistoryBorrowDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"INSERT INTO HistoryBorrow (DetailBorrowReturnBookID, StatusID, BookReturnDate)
                                 VALUES (@DetailBorrowReturnBookID, @StatusID, @BookReturnDate)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DetailBorrowReturnBookID", dto.DetailBorrowReturnBookID);
                cmd.Parameters.AddWithValue("@StatusID", dto.StatusID);
                cmd.Parameters.AddWithValue("@BookReturnDate", dto.BookReturnDate);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(HistoryBorrowDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"UPDATE HistoryBorrow SET 
                                 DetailBorrowReturnBookID = @DetailBorrowReturnBookID,
                                 StatusID = @StatusID,
                                 BookReturnDate = @BookReturnDate
                                 WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", dto.ID);
                cmd.Parameters.AddWithValue("@DetailBorrowReturnBookID", dto.DetailBorrowReturnBookID);
                cmd.Parameters.AddWithValue("@StatusID", dto.StatusID);
                cmd.Parameters.AddWithValue("@BookReturnDate", dto.BookReturnDate);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "DELETE FROM HistoryBorrow WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<HistoryBorrowDTO> GetByDetailBorrowReturnID(int detailBorrowReturnBookId)
        {
            var list = new List<HistoryBorrowDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
                    SELECT h.ID, h.DetailBorrowReturnBookID, h.StatusID, h.BookReturnDate,
                           s.statusName AS StatusName
                    FROM HistoryBorrow h
                    INNER JOIN BookConditionStatus s ON h.StatusID = s.StatusID
                    WHERE h.DetailBorrowReturnBookID = @DetailID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DetailID", detailBorrowReturnBookId);

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new HistoryBorrowDTO
                    {
                        ID = (int)reader["ID"],
                        DetailBorrowReturnBookID = (int)reader["detailBorrowReturnBookID"],
                        StatusID = (int)reader["statusID"],
                        BookReturnDate = Convert.ToDateTime(reader["bookReturnDate"]),
                        StatusName = reader["StatusName"].ToString()
                    });
                }
            }
            return list;
        }
        public List<BookConditionStatusDTO> GetAllStatuses()
        {
            List<BookConditionStatusDTO> statuses = new List<BookConditionStatusDTO>();
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM BookConditionStatus", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    statuses.Add(new BookConditionStatusDTO
                    {
                        StatusID = (int)reader["statusID"],
                        StatusName = reader["statusName"].ToString()
                    });
                }
            }
            return statuses;
        }
        public int InsertAndGetId(HistoryBorrowDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"INSERT INTO HistoryBorrow (DetailBorrowReturnBookID, StatusID, BookReturnDate)
                                 OUTPUT INSERTED.ID
                                 VALUES (@DetailID, @StatusID, @ReturnDate)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DetailID", dto.DetailBorrowReturnBookID);
                cmd.Parameters.AddWithValue("@StatusID", dto.StatusID);
                cmd.Parameters.AddWithValue("@ReturnDate", dto.BookReturnDate);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Shared;

namespace DataLayer
{
    public class BorrowReturnBookRepository
    {
        public List<BorrowReturnBookDTO> GetAllBorrowReturnBooks()
        {
            var list = new List<BorrowReturnBookDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
                    SELECT brb.ID, brb.readerID, brb.userID, brb.dateBorrow, brb.dateReturn, brb.statusID,
                           r.firstName + ' ' + r.lastName AS ReaderName,
                           u.firstName + ' ' + u.lastName AS UserName,
                           bs.statusName AS StatusName
                    FROM BorrowReturnBook brb
                    INNER JOIN Reader r ON brb.readerID = r.readerID
                    INNER JOIN [User] u ON brb.userID = u.userID
                    INNER JOIN BorrowStatus bs ON brb.statusID = bs.statusID";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BorrowReturnBookDTO
                    {
                        ID = (int)reader["ID"],
                        ReaderID = (int)reader["readerID"],
                        UserID = (int)reader["userID"],
                        DateBorrow = Convert.ToDateTime(reader["dateBorrow"]),
                        DateReturn = Convert.ToDateTime(reader["dateReturn"]),
                        StatusID = (int)reader["statusID"],
                        ReaderName = reader["ReaderName"].ToString(),
                        UserName = reader["UserName"].ToString(),
                        StatusName = reader["StatusName"].ToString()
                    });
                }
            }
            return list;
        }

        public List<BorrowStatusDTO> GetAllStatus()
        {
            var list = new List<BorrowStatusDTO>();
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM BorrowStatus";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BorrowStatusDTO
                    {
                        StatusID = (int)reader["statusID"],
                        StatusName = reader["statusName"].ToString()
                    });
                }
            }
            return list;
        }
        public bool Insert(BorrowReturnBookDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"INSERT INTO BorrowReturnBook (readerID, userID, dateBorrow, dateReturn, statusID)
                                 VALUES (@ReaderID, @UserID, @DateBorrow, @DateReturn, @StatusID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReaderID", dto.ReaderID);
                cmd.Parameters.AddWithValue("@UserID", dto.UserID);
                cmd.Parameters.AddWithValue("@DateBorrow", dto.DateBorrow);
                cmd.Parameters.AddWithValue("@DateReturn", dto.DateReturn);
                cmd.Parameters.AddWithValue("@StatusID", dto.StatusID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(BorrowReturnBookDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"UPDATE BorrowReturnBook SET 
                                 readerID = @ReaderID,
                                 userID = @UserID,
                                 dateBorrow = @DateBorrow,
                                 dateReturn = @DateReturn,
                                 statusID = @StatusID
                                 WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", dto.ID);
                cmd.Parameters.AddWithValue("@ReaderID", dto.ReaderID);
                cmd.Parameters.AddWithValue("@UserID", dto.UserID);
                cmd.Parameters.AddWithValue("@DateBorrow", dto.DateBorrow);
                cmd.Parameters.AddWithValue("@DateReturn", dto.DateReturn);
                cmd.Parameters.AddWithValue("@StatusID", dto.StatusID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "DELETE FROM BorrowReturnBook WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<BorrowReturnBookDTO> SearchBorrowReturnByReaderName(string keyword)
        {
            var list = new List<BorrowReturnBookDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
            SELECT brb.ID, brb.readerID, brb.userID, brb.dateBorrow, brb.dateReturn, brb.statusID,
                   r.firstName + ' ' + r.lastName AS ReaderName,
                   u.firstName + ' ' + u.lastName AS UserName,
                   bs.statusName AS StatusName
                    FROM BorrowReturnBook brb
                    INNER JOIN Reader r ON brb.readerID = r.readerID
                    INNER JOIN [User] u ON brb.userID = u.userID
                    INNER JOIN BorrowStatus bs ON brb.statusID = bs.statusID
                    WHERE r.firstName LIKE @kw OR r.lastName LIKE @kw";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BorrowReturnBookDTO
                    {
                        ID = (int)reader["ID"],
                        ReaderID = (int)reader["readerID"],
                        UserID = (int)reader["userID"],
                        DateBorrow = Convert.ToDateTime(reader["dateBorrow"]),
                        DateReturn = Convert.ToDateTime(reader["dateReturn"]),
                        StatusID = (int)reader["statusID"],
                        ReaderName = reader["ReaderName"].ToString(),
                        UserName = reader["UserName"].ToString(),
                        StatusName = reader["StatusName"].ToString()
                    });
                }
            }
            return list;
        }
        public List<BorrowReturnBookDTO> SearchBorrowReturnByReaderId(int id)
        {
            var list = new List<BorrowReturnBookDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
            string query = @"
                    SELECT brb.ID, brb.readerID, brb.userID, brb.dateBorrow, brb.dateReturn, brb.statusID,
                           r.firstName + ' ' + r.lastName AS ReaderName,
                           u.firstName + ' ' + u.lastName AS UserName,
                           bs.statusName AS StatusName
                    FROM BorrowReturnBook brb
                    INNER JOIN Reader r ON brb.readerID = r.readerID
                    INNER JOIN [User] u ON brb.userID = u.userID
                    INNER JOIN BorrowStatus bs ON brb.statusID = bs.statusID
                    WHERE brb.readerID = @ReaderID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReaderID", id);

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BorrowReturnBookDTO
                    {
                        ID = (int)reader["ID"],
                        ReaderID = (int)reader["readerID"],
                        UserID = (int)reader["userID"],
                        DateBorrow = Convert.ToDateTime(reader["dateBorrow"]),
                        DateReturn = Convert.ToDateTime(reader["dateReturn"]),
                        StatusID = (int)reader["statusID"],
                        ReaderName = reader["ReaderName"].ToString(),
                        UserName = reader["UserName"].ToString(),
                        StatusName = reader["StatusName"].ToString()
                    });
                }
            }
            return list;
        }
        public int InsertAndGetId(BorrowReturnBookDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
                    INSERT INTO BorrowReturnBook (readerID, userID, dateBorrow, dateReturn, statusID)
                    OUTPUT INSERTED.ID
                    VALUES (@ReaderID, @UserID, @DateBorrow, @DateReturn, @StatusID)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReaderID", dto.ReaderID);
                cmd.Parameters.AddWithValue("@UserID", dto.UserID);
                cmd.Parameters.AddWithValue("@DateBorrow", dto.DateBorrow);
                cmd.Parameters.AddWithValue("@DateReturn", dto.DateReturn);
                cmd.Parameters.AddWithValue("@StatusID", dto.StatusID);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1; // -1 nếu thất bại
            }
        }
        public List<BorrowedBookInfoDTO> GetBorrowedBooksByReader(int readerId)
        {
            var result = new List<BorrowedBookInfoDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
            SELECT dbrb.ID AS DetailID,dbrb.count AS Count,b.bookID, b.nameBook, brb.dateBorrow, brb.dateReturn
            FROM BorrowReturnBook brb
            INNER JOIN DetailBorrowReturnBook dbrb ON brb.ID = dbrb.borrowReturnBookID
            INNER JOIN Book b ON dbrb.bookID = b.bookID
            WHERE brb.readerID = @ReaderID AND brb.statusID = (
                SELECT statusID FROM BorrowStatus WHERE statusName = 'Borrowing'
            )";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReaderID", readerId);
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime due = Convert.ToDateTime(reader["dateReturn"]);
                    int overdue = (DateTime.Today > due) ? (DateTime.Today - due).Days : 0;
                    decimal fine = overdue * 3000; // ví dụ phạt 3k/ngày

                    result.Add(new BorrowedBookInfoDTO
                    {
                        DetailID = (int)reader["DetailID"],
                        BookID=(int)reader["bookID"],
                        Count=(int)reader["Count"],
                        BookName = reader["nameBook"].ToString(),
                        DateBorrow = Convert.ToDateTime(reader["dateBorrow"]),
                        DateReturn = due,
                        OverdueDays = overdue,
                        FineAmount = fine
                    });
                }
            }

            return result;
        }
         public void MarkAsReturnedByDetailIDs(List<int> detailIds)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();

                string query = @"UPDATE BorrowReturnBook
                                 SET statusID = 2
                                 WHERE ID IN (
                                     SELECT DISTINCT borrowReturnBookID
                                     FROM DetailBorrowReturnBook
                                     WHERE ID IN ({0})
                                 )";

                string ids = string.Join(",", detailIds);
                SqlCommand cmd = new SqlCommand(string.Format(query, ids), conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

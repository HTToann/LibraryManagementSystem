using DTOs;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
    public class StatsRepository
    {
        public ReturnRateDTO GetReturnRate()
        {
            var dto = new ReturnRateDTO();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
                    SELECT 
                        SUM(CASE WHEN hb.bookReturnDate <= brb.dateReturn THEN 1 ELSE 0 END) AS OnTime,
                        SUM(CASE WHEN hb.bookReturnDate > brb.dateReturn THEN 1 ELSE 0 END) AS Overdue
                    FROM HistoryBorrow hb
                    JOIN DetailBorrowReturnBook dbr ON dbr.ID = hb.detailBorrowReturnBookID
                    JOIN BorrowReturnBook brb ON brb.ID = dbr.borrowReturnBookID";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dto.OnTimeCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    dto.OverdueCount = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                }
            }
            return dto;
        }
        public List<BorrowPerMonthDTO> GetBorrowCountPerMonth()
        {
            var result = new List<BorrowPerMonthDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
                    SELECT MONTH(dateBorrow) AS Month, COUNT(*) AS TotalBorrows
                    FROM BorrowReturnBook
                    GROUP BY MONTH(dateBorrow)
                    ORDER BY Month";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new BorrowPerMonthDTO
                    {
                        Month = reader.GetInt32(0),
                        TotalBorrows = reader.GetInt32(1)
                    });
                }
            }
            return result;
        }
        public List<TopBookDTO> GetTop5BorrowedBooks()
        {
            var result = new List<TopBookDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
                    SELECT TOP 5 b.nameBook, COUNT(*) AS BorrowCount
                    FROM DetailBorrowReturnBook db
                    JOIN Book b ON db.bookID = b.bookID
                    GROUP BY b.nameBook
                    ORDER BY BorrowCount DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new TopBookDTO
                    {
                        BookName = reader.GetString(0),
                        BorrowCount = reader.GetInt32(1)
                    });
                }
            }
            return result;
        }
        public List<MonthlyPenaltyDTO> GetTotalPenaltyPerMonth()
        {
            var result = new List<MonthlyPenaltyDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
                    SELECT MONTH(p.penaltyDate) AS Month, SUM(p.fineAmount) AS TotalAmount
                    FROM Penalty p
                    GROUP BY MONTH(p.penaltyDate)
                    ORDER BY Month";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new MonthlyPenaltyDTO
                    {
                        Month = reader.GetInt32(0),
                        TotalAmount = reader.GetDecimal(1)
                    });
                }
            }
            return result;
        }
    }
}

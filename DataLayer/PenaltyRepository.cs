using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTOs;
using Shared;

namespace DataLayer
{
    public class PenaltyRepository
    {
        public List<PenaltyDTO> GetAllPenalties()
        {
            var list = new List<PenaltyDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Penalty";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new PenaltyDTO
                    {
                        ID = (int)reader["ID"],
                        HistoryBorrowID = (int)reader["historyBorrowID"],
                        PenaltyDate = Convert.ToDateTime(reader["penaltyDate"]),
                        NumberOfPenaltyDays = (int)reader["numberOfPenaltyDays"],
                        FineAmount = Convert.ToDecimal(reader["fineAmount"]),
                        Status = Convert.ToBoolean(reader["isPaid"])
                    });
                }
            }
            return list;
        }

        public bool Insert(PenaltyDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"INSERT INTO Penalty (historyBorrowID, penaltyDate, numberOfPenaltyDays, fineAmount, isPaid)
                                 VALUES (@HistoryBorrowID, @PenaltyDate, @Days, @Amount, @Status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HistoryBorrowID", dto.HistoryBorrowID);
                cmd.Parameters.AddWithValue("@PenaltyDate", dto.PenaltyDate);
                cmd.Parameters.AddWithValue("@Days", dto.NumberOfPenaltyDays);
                cmd.Parameters.AddWithValue("@Amount", dto.FineAmount);
                cmd.Parameters.AddWithValue("@Status", dto.Status);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(PenaltyDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"UPDATE Penalty SET
                                 historyBorrowID = @HistoryBorrowID,
                                 penaltyDate = @PenaltyDate,
                                 numberOfPenaltyDays = @Days,
                                 fineAmount = @Amount,
                                 isPaid = @Status
                                 WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", dto.ID);
                cmd.Parameters.AddWithValue("@HistoryBorrowID", dto.HistoryBorrowID);
                cmd.Parameters.AddWithValue("@PenaltyDate", dto.PenaltyDate);
                cmd.Parameters.AddWithValue("@Days", dto.NumberOfPenaltyDays);
                cmd.Parameters.AddWithValue("@Amount", dto.FineAmount);
                cmd.Parameters.AddWithValue("@Status", dto.Status);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "DELETE FROM Penalty WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<PenaltyDTO> GetPennaltyByHistoryBorrowID(int historyBorrowID)
        {
            var list = new List<PenaltyDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"SELECT * FROM Penalty WHERE historyBorrowID = @HistoryBorrowID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HistoryBorrowID", historyBorrowID);

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new PenaltyDTO
                    {
                        ID = (int)reader["ID"],
                        HistoryBorrowID = (int)reader["historyBorrowID"],
                        PenaltyDate = Convert.ToDateTime(reader["penaltyDate"]),
                        NumberOfPenaltyDays = (int)reader["numberOfPenaltyDays"],
                        FineAmount = Convert.ToDecimal(reader["fineAmount"]),
                        Status = Convert.ToBoolean(reader["isPaid"])
                    });
                }
            }
            return list;
        }
    }
}

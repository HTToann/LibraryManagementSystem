using DTOs;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace DataLayer
{
    public class SupplierRepository
    {
        public List<SupplierDTO> GetAllSuppliers()
        {
            var list = new List<SupplierDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Supplier";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new SupplierDTO
                    {
                        SupplierID = (int)reader["supplierID"],
                        Name = reader["name"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Address = reader["address"].ToString(),
                        Gmail = reader["gmail"].ToString()
                    });
                }
            }
            return list;
        }
        public bool InsertSupplier(SupplierDTO supplier)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"INSERT INTO Supplier 
                        (name, phone, address, gmail)
                        VALUES (@Name, @Phone, @Address, @Gmail)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", supplier.Name);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);
                cmd.Parameters.AddWithValue("@Gmail", supplier.Gmail);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool UpdateSupplier(SupplierDTO supplier)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"UPDATE Supplier SET 
                        name = @Name,
                        phone = @Phone,
                        address = @Address,
                        gmail = @Gmail
                        WHERE supplierID = @SupplierID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                cmd.Parameters.AddWithValue("@Name", supplier.Name);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);
                cmd.Parameters.AddWithValue("@Gmail", supplier.Gmail);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool DeleteSupplier(int supplierID)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "DELETE FROM Supplier WHERE supplierID = @SupplierID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SupplierID", supplierID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<SupplierDTO> SearchSupplierByName(string keyword)
        {
            var list = new List<SupplierDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Supplier WHERE name LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new SupplierDTO
                    {
                        SupplierID = (int)reader["supplierID"],
                        Name = reader["name"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Address = reader["address"].ToString(),
                        Gmail = reader["gmail"].ToString()
                    });
                }
            }
            return list;
        }
        public SupplierDTO SearchSupplierByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Supplier WHERE supplierID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new SupplierDTO
                        {
                            SupplierID = (int)reader["supplierID"],
                            Name = reader["name"].ToString(),
                            Phone = reader["phone"].ToString(),
                            Address = reader["address"].ToString(),
                            Gmail = reader["gmail"].ToString()
                        };
                    }
                }
                return null;
            }
        }
    }
}

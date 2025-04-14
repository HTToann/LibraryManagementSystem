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
    public class PublisherRepository
    {
        public List<PublisherDTO> GetAllPublishers()
        {
            var list = new List<PublisherDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Publisher";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new PublisherDTO
                    {
                        PublisherID = (int)reader["publisherID"],
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Gmail = reader["gmail"].ToString()
                    });
                }
            }
            return list;
        }
        public bool InsertPublisher(PublisherDTO publisher)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"INSERT INTO Publisher (name, address, phone, gmail)
                         VALUES (@Name, @Address, @Phone, @Gmail)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", publisher.Name);
                cmd.Parameters.AddWithValue("@Address", publisher.Address);
                cmd.Parameters.AddWithValue("@Phone", publisher.Phone);
                cmd.Parameters.AddWithValue("@Gmail", publisher.Gmail);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdatePublisher(PublisherDTO publisher)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"UPDATE Publisher SET 
                         name = @Name,
                         address = @Address,
                         phone = @Phone,
                         gmail = @Gmail
                         WHERE publisherID = @PublisherID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PublisherID", publisher.PublisherID);
                cmd.Parameters.AddWithValue("@Name", publisher.Name);
                cmd.Parameters.AddWithValue("@Address", publisher.Address);
                cmd.Parameters.AddWithValue("@Phone", publisher.Phone);
                cmd.Parameters.AddWithValue("@Gmail", publisher.Gmail);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeletePublisher(int publisherID)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "DELETE FROM Publisher WHERE publisherID = @PublisherID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PublisherID", publisherID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<PublisherDTO> SearchPublisherByName(string keyword)
        {
            var list = new List<PublisherDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Publisher WHERE name LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new PublisherDTO
                    {
                        PublisherID = (int)reader["publisherID"],
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Gmail = reader["gmail"].ToString()
                    });
                }
            }
            return list;
        }

        public PublisherDTO SearchPublisherById(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Publisher WHERE publisherID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new PublisherDTO
                    {
                        PublisherID = (int)reader["publisherID"],
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Gmail = reader["gmail"].ToString()
                    };
                }
            }
            return null;
        }

    }
}

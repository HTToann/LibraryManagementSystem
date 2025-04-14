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
    public class CategoryRepository
    {
        public List<CategoryDTO> GetAllCategories()
        {
            var list = new List<CategoryDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Category";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new CategoryDTO
                    {
                        CategoryID = (int)reader["categoryID"],
                        Name = reader["name"].ToString()
                    });
                }
            }
            return list;
        }

        public bool InsertCategory(CategoryDTO category)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "INSERT INTO Category (name) VALUES (@Name)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", category.Name);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateCategory(CategoryDTO category)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "UPDATE Category SET name = @Name WHERE categoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                cmd.Parameters.AddWithValue("@Name", category.Name);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteCategory(int categoryID)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "DELETE FROM Category WHERE categoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<CategoryDTO> SearchCategoryByName(string keyword)
        {
            var list = new List<CategoryDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Category WHERE name LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new CategoryDTO
                    {
                        CategoryID = (int)reader["categoryID"],
                        Name = reader["name"].ToString()
                    });
                }
            }
            return list;
        }

        public CategoryDTO SearchCategoryById(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "SELECT * FROM Category WHERE categoryID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new CategoryDTO
                    {
                        CategoryID = (int)reader["categoryID"],
                        Name = reader["name"].ToString()
                    };
                }
            }
            return null;
        }

    }
}

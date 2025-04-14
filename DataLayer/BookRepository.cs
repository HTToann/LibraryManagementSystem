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
    public class BookRepository
    {
        public List<BookDTO> GetAllBooks()
        {
            var list = new List<BookDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
            SELECT b.bookID, b.codeBook, b.nameBook, b.yearOfPublication, b.count,
                   b.categoryID, b.publisherID, b.supplierID,
                   c.name AS CategoryName,
                   p.name AS PublisherName,
                   s.name AS SupplierName
            FROM Book b
            JOIN Category c ON b.categoryID = c.categoryID
            JOIN Publisher p ON b.publisherID = p.publisherID
            JOIN Supplier s ON b.supplierID = s.supplierID";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BookDTO
                    {
                        BookID = (int)reader["bookID"],
                        CodeBook = reader["codeBook"].ToString(),
                        NameBook = reader["nameBook"].ToString(),
                        YearOfPublication = (int)reader["yearOfPublication"],
                        Count = (int)reader["count"],
                        CategoryID = (int)reader["categoryID"],
                        PublisherID = (int)reader["publisherID"],
                        SupplierID = (int)reader["supplierID"],
                        CategoryName = reader["CategoryName"].ToString(),
                        PublisherName = reader["PublisherName"].ToString(),
                        SupplierName = reader["SupplierName"].ToString()
                    });
                }
            }
            return list;
        }
        public bool InsertBook(BookDTO book)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"INSERT INTO Book (codeBook, nameBook, yearOfPublication, count, categoryID, publisherID, supplierID)
                         VALUES (@CodeBook, @NameBook, @Year, @Count, @CategoryID, @PublisherID, @SupplierID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CodeBook", book.CodeBook);
                cmd.Parameters.AddWithValue("@NameBook", book.NameBook);
                cmd.Parameters.AddWithValue("@Year", book.YearOfPublication);
                cmd.Parameters.AddWithValue("@Count", book.Count);
                cmd.Parameters.AddWithValue("@CategoryID", book.CategoryID);
                cmd.Parameters.AddWithValue("@PublisherID", book.PublisherID);
                cmd.Parameters.AddWithValue("@SupplierID", book.SupplierID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateBook(BookDTO book)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"UPDATE Book SET 
                            codeBook = @CodeBook,
                            nameBook = @NameBook,
                            yearOfPublication = @Year,
                            count = @Count,
                            categoryID = @CategoryID,
                            publisherID = @PublisherID,
                            supplierID = @SupplierID
                         WHERE bookID = @BookID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookID", book.BookID);
                cmd.Parameters.AddWithValue("@CodeBook", book.CodeBook);
                cmd.Parameters.AddWithValue("@NameBook", book.NameBook);
                cmd.Parameters.AddWithValue("@Year", book.YearOfPublication);
                cmd.Parameters.AddWithValue("@Count", book.Count);
                cmd.Parameters.AddWithValue("@CategoryID", book.CategoryID);
                cmd.Parameters.AddWithValue("@PublisherID", book.PublisherID);
                cmd.Parameters.AddWithValue("@SupplierID", book.SupplierID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteBook(int bookID)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = "DELETE FROM Book WHERE bookID = @BookID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookID", bookID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<BookDTO> SearchBookByName(string keyword)
        {
            var list = new List<BookDTO>();
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
            SELECT b.*, c.name AS CategoryName, p.name AS PublisherName, s.name AS SupplierName
            FROM Book b
            JOIN Category c ON b.categoryID = c.categoryID
            JOIN Publisher p ON b.publisherID = p.publisherID
            JOIN Supplier s ON b.supplierID = s.supplierID
            WHERE b.nameBook LIKE @Keyword";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BookDTO
                    {
                        BookID = (int)reader["bookID"],
                        CodeBook = reader["codeBook"].ToString(),
                        NameBook = reader["nameBook"].ToString(),
                        YearOfPublication = (int)reader["yearOfPublication"],
                        Count = (int)reader["count"],
                        CategoryID = (int)reader["categoryID"],
                        PublisherID = (int)reader["publisherID"],
                        SupplierID = (int)reader["supplierID"],
                        CategoryName = reader["CategoryName"].ToString(),
                        PublisherName = reader["PublisherName"].ToString(),
                        SupplierName = reader["SupplierName"].ToString()
                    });
                }
            }
            return list;
        }
        public BookDTO SearchBookById(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                string query = @"
            SELECT b.*, 
                   c.name AS CategoryName, 
                   p.name AS PublisherName, 
                   s.name AS SupplierName
            FROM Book b
            JOIN Category c ON b.categoryID = c.categoryID
            JOIN Publisher p ON b.publisherID = p.publisherID
            JOIN Supplier s ON b.supplierID = s.supplierID
            WHERE b.bookID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new BookDTO
                    {
                        BookID = (int)reader["bookID"],
                        CodeBook = reader["codeBook"].ToString(),
                        NameBook = reader["nameBook"].ToString(),
                        YearOfPublication = (int)reader["yearOfPublication"],
                        Count = (int)reader["count"],
                        CategoryID = (int)reader["categoryID"],
                        PublisherID = (int)reader["publisherID"],
                        SupplierID = (int)reader["supplierID"],
                        CategoryName = reader["CategoryName"].ToString(),
                        PublisherName = reader["PublisherName"].ToString(),
                        SupplierName = reader["SupplierName"].ToString()
                    };
                }
            }

            return null;
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> 057b4d8b3eaae73966fe867ed2d53714f6127a6f
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
<<<<<<< HEAD
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
=======
>>>>>>> 057b4d8b3eaae73966fe867ed2d53714f6127a6f
=======
>>>>>>> tomerge
        public void DecreaseStock(int bookId, int count)
        {
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var query = "UPDATE Book SET Count = Count - @Count WHERE BookID = @BookID";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Count", count);
                cmd.Parameters.AddWithValue("@BookID", bookId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void IncreaseStock(int bookId, int count)
        {
            using (var conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var query = "UPDATE Book SET Count = Count + @Count WHERE BookID = @BookID";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Count", count);
                cmd.Parameters.AddWithValue("@BookID", bookId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 057b4d8b3eaae73966fe867ed2d53714f6127a6f
=======

>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======

>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
<<<<<<< HEAD
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
=======
>>>>>>> 057b4d8b3eaae73966fe867ed2d53714f6127a6f
=======
>>>>>>> tomerge
    }
}

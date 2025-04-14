using System.Security.Cryptography;
using System.Text;
namespace Shared
{
    public static class HashPasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (var b in hash)
                {
                    sb.Append(b.ToString("x2")); // chuyển thành chuỗi hex
                }
                return sb.ToString();
            }
        }
    }
}

namespace DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Gmail { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int RoleID { get; set; }

        public string RoleName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}

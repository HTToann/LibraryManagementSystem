namespace DTOs
{
    public class UserRoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public override string ToString()
        {
            return RoleName;
        }
    }
}

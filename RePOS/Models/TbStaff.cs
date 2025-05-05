namespace RePOS.Models
{
    public class TbStaff
    {
        public long Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public long Role { get; set; }
        public TbRole? TbRole { get; set; } 
    }
}

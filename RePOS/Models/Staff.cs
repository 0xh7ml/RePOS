namespace RePOS.Models
{
    public class Staff
    {
        public long Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool isAdmin { get; set; } = false;
    }
}

namespace RePOS.Models
{
    public class TbPermissions
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public ICollection<TbRole>? Roles { get; set; }
    }
}

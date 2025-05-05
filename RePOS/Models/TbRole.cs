namespace RePOS.Models
{
    public class TbRole
    {
        public long Id { get; set; }
        public long Permissions { get; set; }

        public TbPermissions? TbPermissions { get; set; }
        public ICollection<TbStaff>? Staffs { get; set; }
    }
}


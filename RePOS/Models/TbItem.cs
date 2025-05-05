namespace RePOS.Models
{
    public class TbItem
    {
        public long Id { get; set; }
        public long Category { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }

        public TbCategory? TbCategory { get; set; }
        public ICollection<TbOrderItem>? OrderItems { get; set; }
    }
}

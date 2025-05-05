namespace RePOS.Models
{
    public class TbCategory
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;

        public ICollection<TbItem>? Items { get; set; }

    }
}

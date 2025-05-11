namespace RePOS.Models
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long Qty { get; set; }

        public Order? TbOrder { get; set; }
        public Item? TbItem { get; set; }
    }
}

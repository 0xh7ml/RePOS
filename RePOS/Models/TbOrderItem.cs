namespace RePOS.Models
{
    public class TbOrderItem
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ItemId { get; set; }
        public long Qty { get; set; }

        public TbOrder? TbOrder { get; set; }
        public TbItem? TbItem { get; set; }
    }
}

namespace RePOS.Models
{
    public class TbOrder
    {
        public long Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public long Total { get; set; }

        public TbPaymentMethod? TbPaymentMethod { get; set; }
        public ICollection<TbOrderItem>? OrderItems { get; set; }
    }
}

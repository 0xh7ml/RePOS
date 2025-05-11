namespace RePOS.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public long Total { get; set; }

        public PaymentMethod? TbPaymentMethod { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}

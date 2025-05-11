namespace RePOS.Models
{
    public class PaymentMethod
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Order>? Orders { get; set; }
    }
}

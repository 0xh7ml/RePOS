namespace RePOS.Models
{
    public class TbPaymentMethod
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<TbOrder>? Orders { get; set; }
    }
}

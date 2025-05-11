using System.Collections.Generic;
namespace RePOS.Dtos
{
    public class OrderCreateDto
    {
        public int PaymentMethodId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }

    public class OrderItemDto
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}

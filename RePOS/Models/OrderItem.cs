using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePOS.Models
{
    public class OrderItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Order")]
        [Column("order_id")]
        public int OrderId { get; set; }

        [ForeignKey("Item")]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("quantity")]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
    }
}
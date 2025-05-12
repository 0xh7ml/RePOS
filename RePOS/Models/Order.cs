using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePOS.Models
{
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Column("total")]
        [Range(0, 999999.99)]
        public decimal Total { get; set; }

        [ForeignKey("PaymentMethod")]
        [Column("payment_method_id")]
        public int PaymentMethodId { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
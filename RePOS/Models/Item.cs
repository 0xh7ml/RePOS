using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePOS.Models
{
    public class Item
    {
    
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public float Price { get; set; }

        [ForeignKey("TbCategory")]
        public int CategoryId { get; set; }
        
        public virtual Category? TbCategory { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}

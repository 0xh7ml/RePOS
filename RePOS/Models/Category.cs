using System.ComponentModel.DataAnnotations;

namespace RePOS.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Item>? Items { get; set; }

    }
}

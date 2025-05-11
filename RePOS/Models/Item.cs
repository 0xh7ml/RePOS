using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePOS.Models
{
    public class Item
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Column("price")]
        public int Price { get; set; }
    }
}

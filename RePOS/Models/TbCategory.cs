using System.ComponentModel.DataAnnotations;

namespace RePOS.Models
{
    public class TbCategory
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<TbItem>? Items { get; set; }

    }
}

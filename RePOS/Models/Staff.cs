using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePOS.Models
{
    public class Staff
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        [StringLength(255)]
        public string FullName { get; set; }

        [Column("email")] 
        [StringLength(255)]
        public string Email { get; set; }

        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; }

        [Column("isAdmin")]
        public bool IsAdmin { get; set; }

        [Column("status")]
        public bool Status { get; set; }
    }
}

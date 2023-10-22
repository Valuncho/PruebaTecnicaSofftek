using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaSofftek.Models
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        [Required]
        [Column(TypeName = "INT")]
        public int CustomerId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string CustomerName { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaSofftek.Models
{
    [Table("account")]
    public class Account
    {
        [Key]
        [Required]
        [Column(TypeName = "INT")]
        public int AccountId { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL")]
        public decimal Balance { get; set; }        
    }
}

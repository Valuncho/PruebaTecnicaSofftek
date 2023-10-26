using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaSofftek.Models
{
    [Table("CryptoAccount")]
    public class CryptoAccount
    {
        [Key]
        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid AddressUUID { get; set; }
        [Required]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        [Required]
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(38,18)")]
        public decimal CryptoBalance { get; set; }
    }
}

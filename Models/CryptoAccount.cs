using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaSofftek.Models
{
    [Table("cryptoAccount")]
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
    }
}

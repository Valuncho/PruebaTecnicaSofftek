using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaSofftek.Models
{
    [Table("cryptoAccount")]
    public class CryptoAccount
    {
        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid AddressUUID { get; set; }
        [Required]
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}

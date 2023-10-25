using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaSofftek.Models
{
    [Table("transfer")]
    public class Transfer
    {
        [Key]
        [Required]
        [Column(TypeName = "INT")]
        public int TransferId { get; set; }
        [Required]
        [Column(TypeName = "INT")]
        public int Origin { get; set; }
        [Required]
        [Column(TypeName = "INT")]
        public int Destination { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string TransferType { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL")]
        public decimal Amount { get; set; }
        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Date { get; set; }
    }
}

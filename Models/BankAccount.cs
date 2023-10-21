using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaSofftek.Models
{
    [Table("bankAccount")]
    public class BankAccount : Account
    {
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string CBU { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Alias { get; set; }
        [Required]
        [Column(TypeName = "INT")]
        public int AccountNumber { get; set; }
        [Required]
        [Column(TypeName = "INT")]
        public Enum BankAccountType { get; set; }
    }
    public enum BankAccountType
    {
        ARSAccount = 1,
        USDAccount = 2
    }
}

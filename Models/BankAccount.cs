using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaSofftek.Models
{
    [Table("bankAccount")]
    public class BankAccount 
    {
        [Key]
        [Required]
        [Column(TypeName = "INT")]
        public int BankAccountId { get; set; }
        [Required]
        [Column(TypeName = "INT")]
        public int CBU { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Alias { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int AccountNumber { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public BankAccountType Type { get; set; }

        [Required]
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public enum BankAccountType
        {
            ARSAccount = 1,
            USDAccount 
        }
    }
}

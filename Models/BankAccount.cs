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
        //Esto es nuevo

        [Required]
        public int AccountId { get; set; } // Propiedad de navegación hacia Account
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; } // Propiedad de navegación hacia Account

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        // esto es nuevo

        [Required]
        [Column(TypeName = "INT")]
        public int AccountNumber { get; set; }
        [Required]
        [Column(TypeName = "INT")]
        public int CBU { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Alias { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public BankAccountType Type { get; set; }

        public enum BankAccountType
        {
            ARSAccount = 1,
            USDAccount = 2
        }
    }
}

using PruebaTecnicaSofftek.Models;
using static PruebaTecnicaSofftek.Models.BankAccount;

namespace PruebaTecnicaSofftek.DTOs
{
    public class BankAccountDto
    {
        public int BankAccountId { get; set; }
        public int AccountNumber { get; set; }
        public int CustomerId { get; set; }
        public int CBU { get; set; }
        public string Alias { get; set; }
        public BankAccountType Type { get; set; }

    }
}

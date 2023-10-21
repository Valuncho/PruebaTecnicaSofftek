using PruebaTecnicaSofftek.Models;
using static PruebaTecnicaSofftek.Models.BankAccount;

namespace PruebaTecnicaSofftek.DTOs
{
    public class BankAccountDto
    {
        public int bankAccountId { get; set; }
        public int CBU { get; set; }
        public string Alias { get; set; }
        public int AccountNumber { get; set; }
        public BankAccountType Type { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}

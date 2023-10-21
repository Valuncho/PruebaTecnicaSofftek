using PruebaTecnicaSofftek.Models;

namespace PruebaTecnicaSofftek.DTOs
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
    }
}

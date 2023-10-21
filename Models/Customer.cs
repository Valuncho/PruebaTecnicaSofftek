namespace PruebaTecnicaSofftek.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Account List<Account>();
    }
}

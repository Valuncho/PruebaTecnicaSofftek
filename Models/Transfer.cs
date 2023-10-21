namespace PruebaTecnicaSofftek.Models
{
    public class Transfer
    {
        public Account Origin { get; set; }
        public Account Destination { get; set; }
        public decimal Amount { get; set; }
    }
}

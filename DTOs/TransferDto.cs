using PruebaTecnicaSofftek.Models;

namespace PruebaTecnicaSofftek.DTOs
{
    public class TransferDto
    {
        public int transferId { get; set; }
        public Account Origin { get; set; }
        public Account Destination { get; set; }
        public string TransferType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}

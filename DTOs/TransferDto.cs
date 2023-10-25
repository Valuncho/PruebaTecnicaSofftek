using PruebaTecnicaSofftek.Models;

namespace PruebaTecnicaSofftek.DTOs
{
    public class TransferDto
    {
        public int TransferId { get; set; }
        public int Origin { get; set; }
        public int Destination { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}

namespace PruebaTecnicaSofftek.Models
{
    public class BankAccount : Account
    {
        public string CBU { get; set; }
        public string Alias { get; set; }
        public int AccountNumber { get; set; }
        public Enum TypeBankAccount { get; set; }
    }
    public enum TypeBankAccount
    {
        ARSAccount = 1,
        USDAccount = 2
    }
}

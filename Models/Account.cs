using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace PruebaTecnicaSofftek.Models
{
    [Table("account")]
    public class Account
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public decimal GetBalance () { return Balance; }
        public decimal Withdrawal(decimal AmmountToWithdraw) 
        {
            if (Balance > 0 && Balance >= AmmountToWithdraw) 
            {
                Balance -= AmmountToWithdraw;
                return AmmountToWithdraw;
            }
            // Devuelve un valor diferente o lanza una excepción para indicar un retiro fallido.
            // En este caso, estoy devolviendo -1 para indicar un retiro no exitoso.
            return -1;
        }
        public void DepositMoney(decimal MoneyToDeposit) 
        {
            Balance += MoneyToDeposit;
        }
    }
}

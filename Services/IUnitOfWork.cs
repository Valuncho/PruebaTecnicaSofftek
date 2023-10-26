using PruebaTecnicaSofftek.Repositories;

namespace PruebaTecnicaSofftek.Services
{
    public interface IUnitOfWork
    {
        public AccountRepository AccountRepository { get; }
        public BankAccountRepository BankAccountRepository { get; }
        public CustomerRepository CustomerRepository { get; }
        public TransferRepository TransferRepository { get; }
        public CryptoAccountRepository CryptoAccountRepository { get; }
        Task<int> Complete();
    }
}

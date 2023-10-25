using PruebaTecnicaSofftek.DataAccess;
using PruebaTecnicaSofftek.Repositories;
using PruebaTecnicaSofftek.Repositories.Interfaces;

namespace PruebaTecnicaSofftek.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository AccountRepository { get; private set; }
        public BankAccountRepository BankAccountRepository { get; private set; }
        public CustomerRepository CustomerRepository { get; private set; }
        public TransferRepository TransferRepository { get; }

        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            AccountRepository = new AccountRepository(_context);
            BankAccountRepository = new BankAccountRepository(_context);
            CustomerRepository = new CustomerRepository(_context);
            TransferRepository = new TransferRepository(_context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }
    }
}

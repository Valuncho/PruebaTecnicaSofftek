using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.DataAccess;
using PruebaTecnicaSofftek.Models;
using PruebaTecnicaSofftek.Repositories.Interfaces;


namespace PruebaTecnicaSofftek.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override async Task<bool> Update(Account updateAccount)
        {
            var Account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == updateAccount.AccountId);
            if (Account == null) { return false; }

            Account.Balance = updateAccount.Balance;
            
            
            _context.Accounts.Update(Account);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var account = await _context.Accounts.Where(x => x.AccountId == id).FirstOrDefaultAsync();
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Account newAccount)
        {
            try
            {
                var accountExisting = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == newAccount.AccountId);

                if (accountExisting != null)
                {
                    return false;
                }

                _context.Accounts.Add(newAccount);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        // Metodo para buscar cuentas por el campo Origin
        public async Task<Transfer> GetByOrigin(int origin)
        {
            var account = await _context.Transfers.FirstOrDefaultAsync(a => a.Origin == origin);
            return account;
        }

        // Metodo para buscar cuentas por el campo Destination en la controlladora
        public async Task<Transfer> GetByDestination(int destination)
        {
            var account = await _context.Transfers.FirstOrDefaultAsync(a => a.Destination == destination);
            return account;
        }
        public async Task<Account> GetById(int accountId)
        {

            var account = await _context.Accounts.FirstOrDefaultAsync(t => t.AccountId == accountId);
            return account;
        }
    }
}

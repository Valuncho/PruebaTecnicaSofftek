using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.DataAccess;
using PruebaTecnicaSofftek.Models;
using PruebaTecnicaSofftek.Repositories.Interfaces;

namespace PruebaTecnicaSofftek.Repositories
{
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override async Task<bool> Update(BankAccount updateBankAccount)
        {
            var BankAccount = await _context.BankAccounts.FirstOrDefaultAsync(x => x.BankAccountId == updateBankAccount.BankAccountId);
            if (BankAccount == null) { return false; }

            BankAccount.AccountNumber = updateBankAccount.AccountNumber;
            BankAccount.Alias = updateBankAccount.Alias;
            BankAccount.CBU = updateBankAccount.CBU;
            BankAccount.Type = updateBankAccount.Type;

            _context.BankAccounts.Update(BankAccount);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var BankAccount = await _context.BankAccounts.Where(x => x.BankAccountId == id).FirstOrDefaultAsync();
            if (BankAccount != null)
            {
                _context.BankAccounts.Remove(BankAccount);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(BankAccount newBankAccount)
        {
            try
            {
                var BankAccountExisting = await _context.BankAccounts.FirstOrDefaultAsync(x => x.BankAccountId == newBankAccount.BankAccountId);

                if (BankAccountExisting != null)
                {
                    return false;
                }

                _context.BankAccounts.Add(newBankAccount);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<BankAccount> GetById(int accountId)
        {

            var account = await _context.BankAccounts.FirstOrDefaultAsync(t => t.AccountId == accountId);
            return account;
        }
    }
}

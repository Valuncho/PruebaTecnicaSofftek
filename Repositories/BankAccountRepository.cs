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
                var BankAccount = await _context.BanckAccounts.FirstOrDefaultAsync(x => x.BankAccountId== updateBankAccount.BankAccountId);
                if (BankAccount == null) { return false; }

                BankAccount.AccountNumber = updateBankAccount.AccountNumber;
                BankAccount.Alias = updateBankAccount.Alias;
                BankAccount.CBU = updateBankAccount.CBU;
                BankAccount.Type = updateBankAccount.Type;
                
                _context.BanckAccounts.Update(BankAccount);
                await _context.SaveChangesAsync();
                return true;
            }

            public override async Task<bool> Delete(int id)
            {
                var BankAccount = await _context.BanckAccounts.Where(x => x.BankAccountId == id).FirstOrDefaultAsync();
                if (BankAccount != null)
                {
                    _context.BanckAccounts.Remove(BankAccount);
                    await _context.SaveChangesAsync();
                }

                return true;
            }

            public override async Task<bool> Insert(BankAccount newBankAccount)
            {
                try
                {
                    var BankAccountExisting = await _context.BanckAccounts.FirstOrDefaultAsync(x => x.BankAccountId == newBankAccount.BankAccountId);

                    if (BankAccountExisting != null)
                    {
                        return false;
                    }

                    _context.BanckAccounts.Add(newBankAccount);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
}

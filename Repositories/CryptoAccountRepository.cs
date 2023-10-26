using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.DataAccess;
using PruebaTecnicaSofftek.Models;
using PruebaTecnicaSofftek.Repositories.Interfaces;

namespace PruebaTecnicaSofftek.Repositories
{
    public class CryptoAccountRepository : Repository<CryptoAccount>, ICryptoAccountRepository
    {

        public CryptoAccountRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> Insert(CryptoAccount CryptoAccount)
        {
            _context.CryptoAccounts.Add(CryptoAccount);
            await _context.SaveChangesAsync();
            return true;
        }
        // Esto es nuevo
        public async Task<CryptoAccount> GetById(int accountId)
        {

            var cryptoAccount = await _context.CryptoAccounts.FirstOrDefaultAsync(x => x.AccountId == accountId);
            return cryptoAccount;
        }
    }
}

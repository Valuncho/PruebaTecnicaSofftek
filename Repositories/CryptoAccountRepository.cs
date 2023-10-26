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
    }
}

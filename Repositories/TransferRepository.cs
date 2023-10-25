using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.DataAccess;
using PruebaTecnicaSofftek.Models;
using PruebaTecnicaSofftek.Repositories.Interfaces;

namespace PruebaTecnicaSofftek.Repositories
{
    public class TransferRepository : Repository<Transfer>, ITransferRepository
    {
        public TransferRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> Insert(Transfer transfer)
        {
            _context.Transfers.Add(transfer);
            await _context.SaveChangesAsync();
            return true;
        }
        public override async Task<bool> Delete(int id)
        {
            var TransferAccount = await _context.Transfers.Where(x => x.TransferId == id).FirstOrDefaultAsync();
            if (TransferAccount != null)
            {
                _context.Transfers.Remove(TransferAccount);
                await _context.SaveChangesAsync();
            }
            return true;
        }
        /*
        public async Task<Transfer> GetById(int transferId)
        {
            var transfer = await _context.Transfers.FirstOrDefaultAsync(t => t.TransferId == transferId);
            return transfer;
        }*/
        public async Task<Transfer> GetById(int transferId)
        {
            
            var transfer = await _context.Transfers.FirstOrDefaultAsync(t => t.TransferId == transferId);
            return transfer;
        }

    }
}


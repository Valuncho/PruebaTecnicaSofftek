using Microsoft.EntityFrameworkCore;

namespace PruebaTecnicaSofftek.DataAccess.DataBaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDataBase(ModelBuilder modelBuilder);
    }
}

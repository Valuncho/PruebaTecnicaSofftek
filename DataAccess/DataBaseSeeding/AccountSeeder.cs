using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.Models;

namespace PruebaTecnicaSofftek.DataAccess.DataBaseSeeding
{
    public class AccountSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData
            (
                new Account
                {
                    AccountId = 1,
                    Balance = 400000,

                },
                new Account
                {
                    AccountId = 2,
                    Balance = 300,
                }
           );
        }
    }
}

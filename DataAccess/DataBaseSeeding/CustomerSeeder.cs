using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.Models;

namespace PruebaTecnicaSofftek.DataAccess.DataBaseSeeding
{
    public class CustomerSeeder : IEntitySeeder
    {
        // Seeder para preCargar en la DB al primer Customer
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData
            (
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Admin",
                    Email = "admin@gmail.com",
                    Password = "123",
                    Accounts = { 1 },
                }
           );
        }
    }
}

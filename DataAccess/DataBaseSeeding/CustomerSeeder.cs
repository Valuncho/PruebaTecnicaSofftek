using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.Models;

namespace PruebaTecnicaSofftek.DataAccess.DataBaseSeeding
{
    public class CustomerSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData
            (
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Test",
                    Email = "test@gmail.com",
                    Password = "password",                  
                }
           );
        }
    }
}

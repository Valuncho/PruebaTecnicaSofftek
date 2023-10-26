using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.Helpers;
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
                    Password = PasswordEncryptHelper.EncryptPassword("1234", "test@gmail.com")            
                },
                new Customer 
                {
                    CustomerId = 2,
                    CustomerName = "esteEsBueno",
                    Email = "testing@gmail.com",
                    Password = PasswordEncryptHelper.EncryptPassword("1234", "testing@gmail.com")
                }
           );
        }
    }
}

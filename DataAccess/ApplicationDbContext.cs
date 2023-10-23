using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.DataAccess.DataBaseSeeding;
using PruebaTecnicaSofftek.Models;

namespace PruebaTecnicaSofftek.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CryptoAccount> CryptoAccounts { get; set; }
        public DbSet<BankAccount> BanckAccounts { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones y propiedades de navegación
            modelBuilder.Entity<BankAccount>()
                .HasOne(b => b.Account)
                .WithMany()
                .HasForeignKey(b => b.AccountId);

            modelBuilder.Entity<BankAccount>()
                .HasOne(b => b.Customer)
                .WithMany()
                .HasForeignKey(b => b.CustomerId);

            var seeders = new List<IEntitySeeder>
            {
                new AccountSeeder(),
                new CustomerSeeder(),
                new BankAccountSeeder()
            };


            foreach (var seeder in seeders)
            {
                seeder.SeedDataBase(modelBuilder);
            }
        }
    }
}

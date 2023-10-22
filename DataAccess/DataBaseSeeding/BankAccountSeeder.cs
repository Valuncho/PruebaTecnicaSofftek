﻿using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.Models;

namespace PruebaTecnicaSofftek.DataAccess.DataBaseSeeding
{
    public class BankAccountSeeder : IEntitySeeder
    {
        // Seeder para preCargar en la DB al primer BankAccount
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().HasData
            (
                new BankAccount
                {
                    BankAccountId = 1,
                    CBU = 111,
                    Alias = "valuncho.jefe",
                    AccountNumber = 1,
                    Type = BankAccount.BankAccountType.ARSAccount,
                    CustomerId = 1,
                },
                new BankAccount
                {
                    BankAccountId = 2,
                    CBU = 123,
                    Alias = "valuncho.miniJefe",
                    AccountNumber = 2,
                    Type = BankAccount.BankAccountType.USDAccount,
                    CustomerId = 1,
                }
           );
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaTecnicaSofftek.DataAccess;

#nullable disable

namespace PruebaTecnicaSofftek.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PruebaTecnicaSofftek.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .HasColumnType("DECIMAL");

                    b.HasKey("AccountId");

                    b.ToTable("account");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            Balance = 400000m
                        },
                        new
                        {
                            AccountId = 2,
                            Balance = 300m
                        });
                });

            modelBuilder.Entity("PruebaTecnicaSofftek.Models.BankAccount", b =>
                {
                    b.Property<int>("BankAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BankAccountId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("INT");

                    b.Property<int>("AccountNumber")
                        .HasColumnType("INT");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("CBU")
                        .HasColumnType("INT");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INT");

                    b.Property<int>("Type")
                        .HasColumnType("INT");

                    b.HasKey("BankAccountId");

                    b.HasIndex("AccountId");

                    b.HasIndex("CustomerId");

                    b.ToTable("bankAccount");

                    b.HasData(
                        new
                        {
                            BankAccountId = 1,
                            AccountId = 1,
                            AccountNumber = 1,
                            Alias = "valuncho.jefe",
                            CBU = 111,
                            CustomerId = 1,
                            Type = 1
                        },
                        new
                        {
                            BankAccountId = 2,
                            AccountId = 1,
                            AccountNumber = 2,
                            Alias = "valuncho.miniJefe",
                            CBU = 123,
                            CustomerId = 1,
                            Type = 2
                        });
                });

            modelBuilder.Entity("PruebaTecnicaSofftek.Models.CryptoAccount", b =>
                {
                    b.Property<Guid>("AddressUUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("CryptoBalance")
                        .HasColumnType("DECIMAL(38,18)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("AddressUUID");

                    b.ToTable("CryptoAccount");
                });

            modelBuilder.Entity("PruebaTecnicaSofftek.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("customer");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerName = "Test",
                            Email = "test@gmail.com",
                            Password = "d670b690880474251d314c4d83cde47415a610b89e560401cf3419c011be6745"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerName = "esteEsBueno",
                            Email = "testing@gmail.com",
                            Password = "cf1dbe457df8a129c3c764035499d6730341c127ff4d545ac79f75644a70d7be"
                        });
                });

            modelBuilder.Entity("PruebaTecnicaSofftek.Models.Transfer", b =>
                {
                    b.Property<int>("TransferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransferId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATE");

                    b.Property<int>("Destination")
                        .HasColumnType("INT");

                    b.Property<int>("Origin")
                        .HasColumnType("INT");

                    b.Property<string>("TransferType")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("TransferId");

                    b.ToTable("transfer");
                });

            modelBuilder.Entity("PruebaTecnicaSofftek.Models.BankAccount", b =>
                {
                    b.HasOne("PruebaTecnicaSofftek.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaTecnicaSofftek.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}

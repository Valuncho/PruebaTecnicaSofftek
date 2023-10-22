using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaSofftek.Migrations
{
    public partial class creatingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "DECIMAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "bankAccount",
                columns: table => new
                {
                    BankAccountId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CBU = table.Column<int>(type: "INT", nullable: false),
                    Alias = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Type = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankAccount", x => x.BankAccountId);
                });

            migrationBuilder.CreateTable(
                name: "cryptoAccount",
                columns: table => new
                {
                    AddressUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cryptoAccount", x => x.AddressUUID);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "transfer",
                columns: table => new
                {
                    transferId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<int>(type: "INT", nullable: false),
                    Destination = table.Column<int>(type: "INT", nullable: false),
                    TransferType = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfer", x => x.transferId);
                });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "AccountId", "Balance" },
                values: new object[,]
                {
                    { 1, 400m },
                    { 2, 0m }
                });

            migrationBuilder.InsertData(
                table: "bankAccount",
                columns: new[] { "BankAccountId", "AccountNumber", "Alias", "CBU", "CustomerId", "Type" },
                values: new object[,]
                {
                    { 1, 1, "valuncho.jefe", 111, 1, 1 },
                    { 2, 2, "valuncho.miniJefe", 123, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "CustomerId", "CustomerName", "Email", "Password" },
                values: new object[] { 1, "Test", "test@gmail.com", "password" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "bankAccount");

            migrationBuilder.DropTable(
                name: "cryptoAccount");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "transfer");
        }
    }
}

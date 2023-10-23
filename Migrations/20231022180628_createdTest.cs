﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaSofftek.Migrations
{
    public partial class createdTest : Migration
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

            migrationBuilder.CreateTable(
                name: "bankAccount",
                columns: table => new
                {
                    BankAccountId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "INT", nullable: false),
                    CustomerId = table.Column<int>(type: "INT", nullable: false),
                    AccountNumber = table.Column<int>(type: "INT", nullable: false),
                    CBU = table.Column<int>(type: "INT", nullable: false),
                    Alias = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Type = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankAccount", x => x.BankAccountId);
                    table.ForeignKey(
                        name: "FK_bankAccount_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bankAccount_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "AccountId", "Balance" },
                values: new object[] { 1, 400m });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "AccountId", "Balance" },
                values: new object[] { 2, 0m });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "CustomerId", "CustomerName", "Email", "Password" },
                values: new object[] { 1, "Test", "test@gmail.com", "password" });

            migrationBuilder.InsertData(
                table: "bankAccount",
                columns: new[] { "BankAccountId", "AccountId", "AccountNumber", "Alias", "CBU", "CustomerId", "Type" },
                values: new object[] { 1, 1, 1, "valuncho.jefe", 111, 1, 1 });

            migrationBuilder.InsertData(
                table: "bankAccount",
                columns: new[] { "BankAccountId", "AccountId", "AccountNumber", "Alias", "CBU", "CustomerId", "Type" },
                values: new object[] { 2, 1, 2, "valuncho.miniJefe", 123, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_bankAccount_AccountId",
                table: "bankAccount",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_bankAccount_CustomerId",
                table: "bankAccount",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bankAccount");

            migrationBuilder.DropTable(
                name: "cryptoAccount");

            migrationBuilder.DropTable(
                name: "transfer");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaSofftek.Migrations
{
    public partial class CryptoAccountModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "cryptoBalance",
                table: "cryptoAccount",
                type: "DECIMAL",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cryptoBalance",
                table: "cryptoAccount");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaSofftek.Migrations
{
    public partial class CryptoAccountModificationAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cryptoBalance",
                table: "cryptoAccount",
                newName: "CryptoBalance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CryptoBalance",
                table: "cryptoAccount",
                newName: "cryptoBalance");
        }
    }
}

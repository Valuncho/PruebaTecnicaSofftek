using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaSofftek.Migrations
{
    public partial class updatedCustomersSeeders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "transferId",
                table: "transfer",
                newName: "TransferId");

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Password",
                value: "d670b690880474251d314c4d83cde47415a610b89e560401cf3419c011be6745");

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "CustomerId", "CustomerName", "Email", "Password" },
                values: new object[] { 2, "esteEsBueno", "testing@gmail.com", "cf1dbe457df8a129c3c764035499d6730341c127ff4d545ac79f75644a70d7be" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "TransferId",
                table: "transfer",
                newName: "transferId");

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Password",
                value: "password");
        }
    }
}

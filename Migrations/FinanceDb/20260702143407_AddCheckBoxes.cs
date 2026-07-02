using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendServer.Migrations.FinanceDb
{
    /// <inheritdoc />
    public partial class AddCheckBoxes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasInvoice",
                table: "TravelCost",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsValidated",
                table: "TravelCost",
                type: "tinyint(1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasInvoice",
                table: "TravelCost");

            migrationBuilder.DropColumn(
                name: "IsValidated",
                table: "TravelCost");
        }
    }
}

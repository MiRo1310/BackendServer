using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Faktor",
                table: "ProductUnits",
                type: "decimal(12,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ProductUnits",
                type: "decimal(12,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,4)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Faktor",
                table: "ProductUnits",
                type: "decimal(4,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ProductUnits",
                type: "decimal(4,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,4)",
                oldNullable: true);
        }
    }
}

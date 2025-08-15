using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rezepte.Migrations
{
    /// <inheritdoc />
    public partial class RenameHundTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Hund",
                newName: "Hunde");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Hunde",
                newName: "Hund");
        }
    }
}

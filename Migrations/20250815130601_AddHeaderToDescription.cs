using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rezepte.Migrations
{
    /// <inheritdoc />
    public partial class AddHeaderToDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "RecipeDescriptions",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                table: "RecipeDescriptions");
        }
    }
}

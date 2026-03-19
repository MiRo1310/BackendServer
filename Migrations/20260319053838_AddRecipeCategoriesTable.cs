using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendServer.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreparationTimeMin",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeCategory",
                table: "Recipes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "TotalTimeMin",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "PreparationTimeMin",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeCategory",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "TotalTimeMin",
                table: "Recipes");
        }
    }
}

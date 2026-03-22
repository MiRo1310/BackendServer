using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendServer.Migrations
{
    /// <inheritdoc />
    public partial class RenameRecipeCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipeCategory",
                table: "Recipes",
                newName: "RecipeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeCategoryId",
                table: "Recipes",
                column: "RecipeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeCategories_RecipeCategoryId",
                table: "Recipes",
                column: "RecipeCategoryId",
                principalTable: "RecipeCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeCategories_RecipeCategoryId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeCategoryId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "RecipeCategoryId",
                table: "Recipes",
                newName: "RecipeCategory");
        }
    }
}

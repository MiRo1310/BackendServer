using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendServer.Migrations
{
    /// <inheritdoc />
    public partial class RenameProductHeaderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductHeaders_Recipes_RecipeId",
                table: "ProductHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductHeaders",
                table: "ProductHeaders");

            migrationBuilder.RenameTable(
                name: "ProductHeaders",
                newName: "RecipeProductHeaders");

            migrationBuilder.RenameIndex(
                name: "IX_ProductHeaders_RecipeId",
                table: "RecipeProductHeaders",
                newName: "IX_RecipeProductHeaders_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeProductHeaders",
                table: "RecipeProductHeaders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeProductHeaders_Recipes_RecipeId",
                table: "RecipeProductHeaders",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeProductHeaders_Recipes_RecipeId",
                table: "RecipeProductHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeProductHeaders",
                table: "RecipeProductHeaders");

            migrationBuilder.RenameTable(
                name: "RecipeProductHeaders",
                newName: "ProductHeaders");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeProductHeaders_RecipeId",
                table: "ProductHeaders",
                newName: "IX_ProductHeaders_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductHeaders",
                table: "ProductHeaders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHeaders_Recipes_RecipeId",
                table: "ProductHeaders",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

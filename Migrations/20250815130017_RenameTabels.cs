using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendServer.Migrations
{
    /// <inheritdoc />
    public partial class RenameTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productUnits_products_ProductId",
                table: "productUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_recipesHeaderProducts_recipes_RecipeId",
                table: "recipesHeaderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_recipesHeaders_recipes_RecipeId",
                table: "recipesHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_recipesProducts_recipes_RecipeId",
                table: "recipesProducts");

            migrationBuilder.DropTable(
                name: "recipesTextAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_units",
                table: "units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_recipes",
                table: "recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "units",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "recipes",
                newName: "Recipes");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RecipeDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RecipeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDescriptions_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDescriptions_RecipeId",
                table: "RecipeDescriptions",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_productUnits_Products_ProductId",
                table: "productUnits",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipesHeaderProducts_Recipes_RecipeId",
                table: "recipesHeaderProducts",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipesHeaders_Recipes_RecipeId",
                table: "recipesHeaders",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipesProducts_Recipes_RecipeId",
                table: "recipesProducts",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productUnits_Products_ProductId",
                table: "productUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_recipesHeaderProducts_Recipes_RecipeId",
                table: "recipesHeaderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_recipesHeaders_Recipes_RecipeId",
                table: "recipesHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_recipesProducts_Recipes_RecipeId",
                table: "recipesProducts");

            migrationBuilder.DropTable(
                name: "RecipeDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "units");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "recipes");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_units",
                table: "units",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recipes",
                table: "recipes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "recipesTextAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RecipeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipesTextAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipesTextAreas_recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_recipesTextAreas_RecipeId",
                table: "recipesTextAreas",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_productUnits_products_ProductId",
                table: "productUnits",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipesHeaderProducts_recipes_RecipeId",
                table: "recipesHeaderProducts",
                column: "RecipeId",
                principalTable: "recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipesHeaders_recipes_RecipeId",
                table: "recipesHeaders",
                column: "RecipeId",
                principalTable: "recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipesProducts_recipes_RecipeId",
                table: "recipesProducts",
                column: "RecipeId",
                principalTable: "recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

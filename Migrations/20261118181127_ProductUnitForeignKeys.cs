using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendServer.Migrations
{
    /// <summary>
    /// Replaces the free text columns Products.Unit and ProductUnits.Unit with a foreign key to Units.
    /// Existing texts are mapped to Units by name; texts without a matching Unit get a new Unit row.
    /// Empty texts are mapped to the unit "Unbekannt".
    /// </summary>
    public partial class ProductUnitForeignKeys : Migration
    {
        private const string NormalizedProductUnit = "COALESCE(NULLIF(TRIM(p.Unit), ''), 'Unbekannt')";
        private const string NormalizedProductUnitsUnit = "COALESCE(NULLIF(TRIM(pu.Unit), ''), 'Unbekannt')";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Add the new columns as nullable, so existing rows stay valid for now
            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "ProductUnits",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "Products",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            // 2. Create missing Units for all texts that have no matching Unit yet
            migrationBuilder.Sql($"""
                INSERT INTO Units (Id, Name, CreatedAt)
                SELECT UUID(), t.Name, UTC_TIMESTAMP(6)
                FROM (
                    SELECT {NormalizedProductUnit} AS Name FROM Products p
                    UNION
                    SELECT {NormalizedProductUnitsUnit} AS Name FROM ProductUnits pu
                ) t
                WHERE NOT EXISTS (SELECT 1 FROM Units u WHERE u.Name = t.Name);
                """);

            // 3. Map the texts to the Unit ids (oldest Unit wins if names are duplicated)
            migrationBuilder.Sql($"""
                UPDATE Products p
                SET p.UnitId = (
                    SELECT u.Id FROM Units u
                    WHERE u.Name = {NormalizedProductUnit}
                    ORDER BY u.CreatedAt
                    LIMIT 1);
                """);

            migrationBuilder.Sql($"""
                UPDATE ProductUnits pu
                SET pu.UnitId = (
                    SELECT u.Id FROM Units u
                    WHERE u.Name = {NormalizedProductUnitsUnit}
                    ORDER BY u.CreatedAt
                    LIMIT 1);
                """);

            // 4. Now every row has a UnitId -> make it required and drop the old text columns
            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "ProductUnits",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "Products",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Products");

            // 5. Index + foreign keys (Restrict: a Unit in use cannot be deleted)
            migrationBuilder.CreateIndex(
                name: "IX_ProductUnits_UnitId",
                table: "ProductUnits",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Units_UnitId",
                table: "Products",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnits_Units_UnitId",
                table: "ProductUnits",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Restore the text columns from the Unit names before dropping the foreign keys
            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "ProductUnits",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Products",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.Sql("""
                UPDATE Products p JOIN Units u ON u.Id = p.UnitId
                SET p.Unit = u.Name;
                """);

            migrationBuilder.Sql("""
                UPDATE ProductUnits pu JOIN Units u ON u.Id = pu.UnitId
                SET pu.Unit = LEFT(u.Name, 20);
                """);

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Units_UnitId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnits_Units_UnitId",
                table: "ProductUnits");

            migrationBuilder.DropIndex(
                name: "IX_ProductUnits_UnitId",
                table: "ProductUnits");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Products");
        }
    }
}

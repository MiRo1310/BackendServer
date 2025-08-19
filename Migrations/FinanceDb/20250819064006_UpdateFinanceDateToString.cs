using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendServer.Migrations.FinanceDb
{
    /// <inheritdoc />
    public partial class UpdateFinanceDateToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "TravelCost",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TravelCost_AddressId",
                table: "TravelCost",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelCost_Addresses_AddressId",
                table: "TravelCost",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelCost_Addresses_AddressId",
                table: "TravelCost");

            migrationBuilder.DropIndex(
                name: "IX_TravelCost_AddressId",
                table: "TravelCost");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TravelCost",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}

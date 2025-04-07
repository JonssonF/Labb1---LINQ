using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb1___LINQ.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLaptop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Suppliers_SupplierId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_SupplierId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Suppliers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "SupplierId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "SupplierId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3,
                column: "SupplierId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 4,
                column: "SupplierId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 5,
                column: "SupplierId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 6,
                column: "SupplierId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierId",
                table: "Suppliers",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Suppliers_SupplierId",
                table: "Suppliers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}

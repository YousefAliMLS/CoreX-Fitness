using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI.Migrations
{
    /// <inheritdoc />
    public partial class AddingSuppliersWithNavProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Supplierid",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Supplierid",
                table: "Products",
                column: "Supplierid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_Supplierid",
                table: "Products",
                column: "Supplierid",
                principalTable: "Suppliers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_Supplierid",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Supplierid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Supplierid",
                table: "Products");
        }
    }
}

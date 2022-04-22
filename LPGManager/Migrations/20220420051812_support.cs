using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class support : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SupportQty",
                table: "SellsDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SupportQty",
                table: "PurchasesDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SupportQty",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupportQty",
                table: "SellsDetails");

            migrationBuilder.DropColumn(
                name: "SupportQty",
                table: "PurchasesDetails");

            migrationBuilder.DropColumn(
                name: "SupportQty",
                table: "Inventories");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class exchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PurchaseReturn",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseReturn",
                table: "Inventories");
        }
    }
}

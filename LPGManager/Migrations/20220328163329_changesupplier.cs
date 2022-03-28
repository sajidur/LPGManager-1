using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class changesupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Suppliers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

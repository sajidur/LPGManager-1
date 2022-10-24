using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class delivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryBy",
                schema: "public",
                table: "SellMasters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryStatus",
                schema: "public",
                table: "SellMasters",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryBy",
                schema: "public",
                table: "SellMasters");

            migrationBuilder.DropColumn(
                name: "DeliveryStatus",
                schema: "public",
                table: "SellMasters");
        }
    }
}

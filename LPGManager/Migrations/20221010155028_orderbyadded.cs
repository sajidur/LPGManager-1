using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class orderbyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "public",
                table: "SellMasters");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "public",
                table: "PurchaseMasters");

            migrationBuilder.AddColumn<string>(
                name: "OrderBy",
                schema: "public",
                table: "SellMasters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiveBy",
                schema: "public",
                table: "SellMasters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderBy",
                schema: "public",
                table: "PurchaseMasters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiveBy",
                schema: "public",
                table: "PurchaseMasters",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderBy",
                schema: "public",
                table: "SellMasters");

            migrationBuilder.DropColumn(
                name: "ReceiveBy",
                schema: "public",
                table: "SellMasters");

            migrationBuilder.DropColumn(
                name: "OrderBy",
                schema: "public",
                table: "PurchaseMasters");

            migrationBuilder.DropColumn(
                name: "ReceiveBy",
                schema: "public",
                table: "PurchaseMasters");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                schema: "public",
                table: "SellMasters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                schema: "public",
                table: "PurchaseMasters",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

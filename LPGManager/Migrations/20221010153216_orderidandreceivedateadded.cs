using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class orderidandreceivedateadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                schema: "public",
                table: "SellMasters",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiveDate",
                schema: "public",
                table: "PurchaseMasters",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                schema: "public",
                table: "SellMasters");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "public",
                table: "SellMasters");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "public",
                table: "PurchaseMasters");

            migrationBuilder.DropColumn(
                name: "ReceiveDate",
                schema: "public",
                table: "PurchaseMasters");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class customerrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SellMasters_CustomerId",
                table: "SellMasters",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellMasters_Customers_CustomerId",
                table: "SellMasters",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellMasters_Customers_CustomerId",
                table: "SellMasters");

            migrationBuilder.DropIndex(
                name: "IX_SellMasters_CustomerId",
                table: "SellMasters");
        }
    }
}

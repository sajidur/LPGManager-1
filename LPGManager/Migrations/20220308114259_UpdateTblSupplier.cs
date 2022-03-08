using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class UpdateTblSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "PurchasesDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "PurchaseMasters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetails_SupplierId",
                table: "PurchasesDetails",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseMasters_SupplierId",
                table: "PurchaseMasters",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseMasters_Suppliers_SupplierId",
                table: "PurchaseMasters",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesDetails_Suppliers_SupplierId",
                table: "PurchasesDetails",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseMasters_Suppliers_SupplierId",
                table: "PurchaseMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesDetails_Suppliers_SupplierId",
                table: "PurchasesDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchasesDetails_SupplierId",
                table: "PurchasesDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseMasters_SupplierId",
                table: "PurchaseMasters");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "PurchasesDetails");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "PurchaseMasters");
        }
    }
}

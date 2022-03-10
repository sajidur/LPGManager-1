using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class TblUpdateRela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseMasters_Suppliers_SupplierId",
                table: "PurchaseMasters");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseMasters_SupplierId",
                table: "PurchaseMasters");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SupplierId",
                table: "Inventories",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_WarehouseId",
                table: "Inventories",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Suppliers_SupplierId",
                table: "Inventories",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId",
                table: "Inventories",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Suppliers_SupplierId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_SupplierId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_WarehouseId",
                table: "Inventories");

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
        }
    }
}

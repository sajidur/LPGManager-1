using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class updateentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Companies_CompanyId1",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Suppliers_CompanyId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId1",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesDetails_Suppliers_CompanyId",
                table: "PurchasesDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchasesDetails_CompanyId",
                table: "PurchasesDetails");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_CompanyId1",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_WarehouseId1",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "WarehouseId1",
                table: "Inventories");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Companies_CompanyId",
                table: "Inventories",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Companies_CompanyId",
                table: "Inventories");

            migrationBuilder.AddColumn<long>(
                name: "CompanyId1",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WarehouseId1",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetails_CompanyId",
                table: "PurchasesDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CompanyId1",
                table: "Inventories",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_WarehouseId1",
                table: "Inventories",
                column: "WarehouseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Companies_CompanyId1",
                table: "Inventories",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Suppliers_CompanyId",
                table: "Inventories",
                column: "CompanyId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId1",
                table: "Inventories",
                column: "WarehouseId1",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesDetails_Suppliers_CompanyId",
                table: "PurchasesDetails",
                column: "CompanyId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class createInitials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId1",
                table: "Inventories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId1",
                table: "Inventories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    AdjustmentAmount = table.Column<string>(type: "text", nullable: false),
                    DueAdvance = table.Column<int>(type: "integer", nullable: true),
                    ReceivingQuantity = table.Column<int>(type: "integer", nullable: true),
                    ReturnQuantity = table.Column<int>(type: "integer", nullable: true),
                    DamageQuantity = table.Column<int>(type: "integer", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ComapnyId = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exchanges_Companies_ComapnyId",
                        column: x => x.ComapnyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exchanges_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SupplierId1",
                table: "Inventories",
                column: "SupplierId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_WarehouseId1",
                table: "Inventories",
                column: "WarehouseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_ComapnyId",
                table: "Exchanges",
                column: "ComapnyId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_CompanyId",
                table: "Exchanges",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Suppliers_SupplierId1",
                table: "Inventories",
                column: "SupplierId1",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId1",
                table: "Inventories",
                column: "WarehouseId1",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Suppliers_SupplierId1",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId1",
                table: "Inventories");

            migrationBuilder.DropTable(
                name: "Exchanges");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_SupplierId1",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_WarehouseId1",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "SupplierId1",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "WarehouseId1",
                table: "Inventories");
        }
    }
}

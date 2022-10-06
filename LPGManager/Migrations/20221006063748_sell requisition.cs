using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class sellrequisition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                newName: "Warehouses",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Tenants",
                newName: "Tenants",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Suppliers",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Sizes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "SellsDetails",
                newName: "SellsDetails",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "SellMasters",
                newName: "SellMasters",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ReturnMasters",
                newName: "ReturnMasters",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ReturnDetails",
                newName: "ReturnDetails",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "PurchasesDetails",
                newName: "PurchasesDetails",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "PurchaseMasters",
                newName: "PurchaseMasters",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "ProductTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Inventories",
                newName: "Inventories",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ExchangeMasters",
                newName: "ExchangeMasters",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ExchangeDetails",
                newName: "ExchangeDetails",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customers",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "CustomerDealersMapping",
                newName: "CustomerDealersMapping",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Companies",
                newSchema: "public");

            migrationBuilder.CreateTable(
                name: "SellRequisitionMasters",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceNo = table.Column<string>(type: "text", nullable: false),
                    InvoiceDate = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellRequisitionMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellRequisitionMasters_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellRequisitionDetails",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    ProductType = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    FilledQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    SellRequisitionMasterId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellRequisitionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellRequisitionDetails_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "public",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellRequisitionDetails_SellRequisitionMasters_SellRequisiti~",
                        column: x => x.SellRequisitionMasterId,
                        principalSchema: "public",
                        principalTable: "SellRequisitionMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellRequisitionDetails_CompanyId",
                schema: "public",
                table: "SellRequisitionDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SellRequisitionDetails_SellRequisitionMasterId",
                schema: "public",
                table: "SellRequisitionDetails",
                column: "SellRequisitionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SellRequisitionMasters_CustomerId",
                schema: "public",
                table: "SellRequisitionMasters",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellRequisitionDetails",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SellRequisitionMasters",
                schema: "public");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                schema: "public",
                newName: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "public",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Tenants",
                schema: "public",
                newName: "Tenants");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                schema: "public",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Sizes",
                schema: "public",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "SellsDetails",
                schema: "public",
                newName: "SellsDetails");

            migrationBuilder.RenameTable(
                name: "SellMasters",
                schema: "public",
                newName: "SellMasters");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "public",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "ReturnMasters",
                schema: "public",
                newName: "ReturnMasters");

            migrationBuilder.RenameTable(
                name: "ReturnDetails",
                schema: "public",
                newName: "ReturnDetails");

            migrationBuilder.RenameTable(
                name: "PurchasesDetails",
                schema: "public",
                newName: "PurchasesDetails");

            migrationBuilder.RenameTable(
                name: "PurchaseMasters",
                schema: "public",
                newName: "PurchaseMasters");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                schema: "public",
                newName: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "public",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Inventories",
                schema: "public",
                newName: "Inventories");

            migrationBuilder.RenameTable(
                name: "ExchangeMasters",
                schema: "public",
                newName: "ExchangeMasters");

            migrationBuilder.RenameTable(
                name: "ExchangeDetails",
                schema: "public",
                newName: "ExchangeDetails");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "public",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "CustomerDealersMapping",
                schema: "public",
                newName: "CustomerDealersMapping");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "public",
                newName: "Companies");
        }
    }
}

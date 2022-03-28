using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Suppliers_SupplierId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Suppliers_SupplierId1",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesDetails_Suppliers_SupplierId",
                table: "PurchasesDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_PurchasesDetails_SupplierId",
                table: "PurchasesDetails");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_SupplierId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_SupplierId1",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "SellsDetails",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "SellMasters",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "PurchasesDetails",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "PurchasesDetails",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "PurchaseMasters",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "SupplierId1",
                table: "Inventories",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Inventories",
                newName: "UpdatedDate");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Warehouses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Warehouses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Warehouses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Warehouses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Warehouses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Warehouses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Suppliers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Suppliers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Suppliers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Suppliers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Suppliers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Sizes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Sizes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Sizes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Sizes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Sizes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "SellMasterId",
                table: "SellsDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReturnQuantity",
                table: "SellsDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ReceivingQuantity",
                table: "SellsDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "SellsDetails",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "SellsDetails",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningQuantity",
                table: "SellsDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DamageQuantity",
                table: "SellsDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "SellsDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "SellsDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SellsDetails",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "SellsDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "SellsDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "SellMasters",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentType",
                table: "SellMasters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DueAdvance",
                table: "SellMasters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "SellMasters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "SellMasters",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "SellMasters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SellMasters",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "SellMasters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "SellMasters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Roles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Roles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Roles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Roles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "SaleQuantity",
                table: "PurchasesDetails",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReturnQuantity",
                table: "PurchasesDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ReceivingQuantity",
                table: "PurchasesDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "PurchasesDetails",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "PurchaseMasterId",
                table: "PurchasesDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ProductType",
                table: "PurchasesDetails",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "PurchasesDetails",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningQuantity",
                table: "PurchasesDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DamageQuantity",
                table: "PurchasesDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "PurchasesDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<decimal>(
                name: "Commission",
                table: "PurchasesDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "PurchasesDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "PurchasesDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchasesDetails",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "PurchasesDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "PurchaseMasters",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCommission",
                table: "PurchaseMasters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                table: "PurchaseMasters",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "PurchaseMasters",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DueAdvance",
                table: "PurchaseMasters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "PurchaseMasters",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "PurchaseMasters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchaseMasters",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "PurchaseMasters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "PurchaseMasters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ProductTypes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "ProductTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductTypes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "ProductTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "ProductTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ProductTypes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "WarehouseId1",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "WarehouseId",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "SaleQuantity",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReturnQuantity",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ReceivingQuantity",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductType",
                table: "Inventories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningQuantity",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DamageQuantity",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId1",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Inventories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "Exchanges",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "ComapnyId",
                table: "Exchanges",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Exchanges",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Exchanges",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Exchanges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Exchanges",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Exchanges",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Exchanges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Companies",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Companies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetails_CompanyId",
                table: "PurchasesDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CompanyId",
                table: "Inventories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CompanyId1",
                table: "Inventories",
                column: "CompanyId1");

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
                name: "FK_PurchasesDetails_Suppliers_CompanyId",
                table: "PurchasesDetails",
                column: "CompanyId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Companies_CompanyId1",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Suppliers_CompanyId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesDetails_Suppliers_CompanyId",
                table: "PurchasesDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_PurchasesDetails_CompanyId",
                table: "PurchasesDetails");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_CompanyId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_CompanyId1",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SellsDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SellsDetails");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SellsDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SellsDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SellMasters");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SellMasters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SellMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SellMasters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Commission",
                table: "PurchasesDetails");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "PurchasesDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchasesDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchasesDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchasesDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchaseMasters");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchaseMasters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PurchaseMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchaseMasters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "SellsDetails",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "SellMasters",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "PurchasesDetails",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "PurchasesDetails",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "PurchaseMasters",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Inventories",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Inventories",
                newName: "SupplierId1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Warehouses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Sizes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "SellMasterId",
                table: "SellsDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnQuantity",
                table: "SellsDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "ReceivingQuantity",
                table: "SellsDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "SellsDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "SellsDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "OpeningQuantity",
                table: "SellsDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "DamageQuantity",
                table: "SellsDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SellsDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "SellMasters",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentType",
                table: "SellMasters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "DueAdvance",
                table: "SellMasters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "SellMasters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SellMasters",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Roles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "SaleQuantity",
                table: "PurchasesDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnQuantity",
                table: "PurchasesDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "ReceivingQuantity",
                table: "PurchasesDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "PurchasesDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseMasterId",
                table: "PurchasesDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "ProductType",
                table: "PurchasesDetails",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "PurchasesDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "OpeningQuantity",
                table: "PurchasesDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "DamageQuantity",
                table: "PurchasesDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PurchasesDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "PurchaseMasters",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "TotalCommission",
                table: "PurchaseMasters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "PurchaseMasters",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentType",
                table: "PurchaseMasters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "DueAdvance",
                table: "PurchaseMasters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PurchaseMasters",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductTypes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId1",
                table: "Inventories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "Inventories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "SaleQuantity",
                table: "Inventories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnQuantity",
                table: "Inventories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "ReceivingQuantity",
                table: "Inventories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Inventories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "ProductType",
                table: "Inventories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Inventories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "OpeningQuantity",
                table: "Inventories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "DamageQuantity",
                table: "Inventories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Inventories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Inventories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Exchanges",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ComapnyId",
                table: "Exchanges",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Exchanges",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Companies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetails_SupplierId",
                table: "PurchasesDetails",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SupplierId",
                table: "Inventories",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SupplierId1",
                table: "Inventories",
                column: "SupplierId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Suppliers_SupplierId",
                table: "Inventories",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Suppliers_SupplierId1",
                table: "Inventories",
                column: "SupplierId1",
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
    }
}

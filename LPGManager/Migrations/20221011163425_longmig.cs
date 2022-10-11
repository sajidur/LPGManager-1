using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class longmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "text", nullable: true),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CompanyType = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDealersMapping",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RefCustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerType = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDealersMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CustomerType = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeMasters",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceDate = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceNo = table.Column<string>(type: "text", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false),
                    TotalPricePaid = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalPriceReceive = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_ExchangeMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseMasters",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceDate = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceNo = table.Column<string>(type: "text", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCommission = table.Column<decimal>(type: "numeric", nullable: false),
                    DueAdvance = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    ReceiveDate = table.Column<long>(type: "bigint", nullable: false),
                    ReceiveBy = table.Column<string>(type: "text", nullable: false),
                    OrderBy = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_PurchaseMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReturnMasters",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SellMasterId = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceNo = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    TotalReturnAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    DueAdvance = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_ReturnMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupplierName = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Companytype = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantName = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Tenanttype = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeDetails",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    ProductType = table.Column<string>(type: "text", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    ExchangeMasterId = table.Column<long>(type: "bigint", nullable: false),
                    ExchangeType = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeDetails_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "public",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellMasters",
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
                    DueAdvance = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DeliveryDate = table.Column<long>(type: "bigint", nullable: false),
                    ReceiveBy = table.Column<string>(type: "text", nullable: false),
                    OrderBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellMasters_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "PurchasesDetails",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    ProductType = table.Column<string>(type: "text", nullable: false),
                    Commission = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    OpeningQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    ReceivingQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    ReturnQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    DamageQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    SaleQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    SupportQty = table.Column<decimal>(type: "numeric", nullable: false),
                    PurchaseMasterId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesDetails_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "public",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasesDetails_PurchaseMasters_PurchaseMasterId",
                        column: x => x.PurchaseMasterId,
                        principalSchema: "public",
                        principalTable: "PurchaseMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnDetails",
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
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    OpeningQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    ReceivingQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    ReturnQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    DamageQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    ReturnMasterId = table.Column<long>(type: "bigint", nullable: false),
                    SellMasterId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnDetails_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "public",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnDetails_ReturnMasters_ReturnMasterId",
                        column: x => x.ReturnMasterId,
                        principalSchema: "public",
                        principalTable: "ReturnMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    ProductType = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    OpeningQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    PurchaseReturn = table.Column<decimal>(type: "numeric", nullable: false),
                    ReceivingQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    ReturnQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    DamageQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    SaleQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    SupportQty = table.Column<decimal>(type: "numeric", nullable: false),
                    ExchangeQty = table.Column<decimal>(type: "numeric", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "public",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "public",
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellsDetails",
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
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    OpeningQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    ReceivingQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    ReturnQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    DamageQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    SellMasterId = table.Column<long>(type: "bigint", nullable: false),
                    SupportQty = table.Column<decimal>(type: "numeric", nullable: false),
                    IsReturn = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellsDetails_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "public",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellsDetails_SellMasters_SellMasterId",
                        column: x => x.SellMasterId,
                        principalSchema: "public",
                        principalTable: "SellMasters",
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
                name: "IX_ExchangeDetails_CompanyId",
                schema: "public",
                table: "ExchangeDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CompanyId",
                schema: "public",
                table: "Inventories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_WarehouseId",
                schema: "public",
                table: "Inventories",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetails_CompanyId",
                schema: "public",
                table: "PurchasesDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetails_PurchaseMasterId",
                schema: "public",
                table: "PurchasesDetails",
                column: "PurchaseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnDetails_CompanyId",
                schema: "public",
                table: "ReturnDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnDetails_ReturnMasterId",
                schema: "public",
                table: "ReturnDetails",
                column: "ReturnMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                schema: "public",
                table: "Roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SellMasters_CustomerId",
                schema: "public",
                table: "SellMasters",
                column: "CustomerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SellsDetails_CompanyId",
                schema: "public",
                table: "SellsDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SellsDetails_SellMasterId",
                schema: "public",
                table: "SellsDetails",
                column: "SellMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDealersMapping",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ExchangeDetails",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ExchangeMasters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Inventories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProductTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PurchasesDetails",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ReturnDetails",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SellRequisitionDetails",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SellsDetails",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Sizes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Warehouses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PurchaseMasters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ReturnMasters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SellRequisitionMasters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SellMasters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "public");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class relationchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SellsDetails_CompanyId",
                table: "SellsDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetails_CompanyId",
                table: "PurchasesDetails",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesDetails_Companies_CompanyId",
                table: "PurchasesDetails",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellsDetails_Companies_CompanyId",
                table: "SellsDetails",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesDetails_Companies_CompanyId",
                table: "PurchasesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SellsDetails_Companies_CompanyId",
                table: "SellsDetails");

            migrationBuilder.DropIndex(
                name: "IX_SellsDetails_CompanyId",
                table: "SellsDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchasesDetails_CompanyId",
                table: "PurchasesDetails");
        }
    }
}

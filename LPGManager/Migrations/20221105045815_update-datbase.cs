using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPGManager.Migrations
{
    public partial class updatedatbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalDue",
                schema: "public",
                table: "SellMasters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPaid",
                schema: "public",
                table: "SellMasters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<long>(
                name: "ReferanceId",
                schema: "public",
                table: "LedgerPostings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDue",
                schema: "public",
                table: "SellMasters");

            migrationBuilder.DropColumn(
                name: "TotalPaid",
                schema: "public",
                table: "SellMasters");

            migrationBuilder.AlterColumn<int>(
                name: "ReferanceId",
                schema: "public",
                table: "LedgerPostings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}

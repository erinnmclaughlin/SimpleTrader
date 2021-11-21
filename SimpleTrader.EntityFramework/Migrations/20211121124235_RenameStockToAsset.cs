using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleTrader.EntityFramework.Migrations
{
    public partial class RenameStockToAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock_Symbol",
                table: "AssetTransactions",
                newName: "Asset_Symbol");

            migrationBuilder.RenameColumn(
                name: "Stock_SharePrice",
                table: "AssetTransactions",
                newName: "Asset_SharePrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Asset_Symbol",
                table: "AssetTransactions",
                newName: "Stock_Symbol");

            migrationBuilder.RenameColumn(
                name: "Asset_SharePrice",
                table: "AssetTransactions",
                newName: "Stock_SharePrice");
        }
    }
}

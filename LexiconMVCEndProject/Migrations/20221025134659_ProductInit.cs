using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVCEndProject.Migrations
{
    public partial class ProductInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Brand", "CategoryID", "Description", "IMG", "Name", "Price", "ProductSaldo" },
                values: new object[] { 1, "Steel Series", 1, "A pair of Steelseries headset", "...", "Steelseries 7", 1000.0, 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Product");
        }
    }
}

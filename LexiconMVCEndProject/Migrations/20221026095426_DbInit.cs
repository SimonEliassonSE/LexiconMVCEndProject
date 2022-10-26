using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVCEndProject.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Customers_CustomerId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrder_Carts_CartId",
                table: "SalesOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesOrder",
                table: "SalesOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.RenameTable(
                name: "SalesOrder",
                newName: "SalesOrders");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Receipts");

            migrationBuilder.RenameIndex(
                name: "IX_SalesOrder_CartId",
                table: "SalesOrders",
                newName: "IX_SalesOrders_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_CustomerId",
                table: "Receipts",
                newName: "IX_Receipts_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesOrders",
                table: "SalesOrders",
                column: "SalesOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Customers_CustomerId",
                table: "Receipts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Carts_CartId",
                table: "SalesOrders",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Customers_CustomerId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Carts_CartId",
                table: "SalesOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesOrders",
                table: "SalesOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.RenameTable(
                name: "SalesOrders",
                newName: "SalesOrder");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "Receipt");

            migrationBuilder.RenameIndex(
                name: "IX_SalesOrders_CartId",
                table: "SalesOrder",
                newName: "IX_SalesOrder_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_CustomerId",
                table: "Receipt",
                newName: "IX_Receipt_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesOrder",
                table: "SalesOrder",
                column: "SalesOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Customers_CustomerId",
                table: "Receipt",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrder_Carts_CartId",
                table: "SalesOrder",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

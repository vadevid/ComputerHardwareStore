using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinKompTechnikiDLL.Migrations
{
    public partial class Migrationsv8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guarantee_Order_OrderID",
                table: "Guarantee");

            migrationBuilder.DropIndex(
                name: "IX_Guarantee_OrderID",
                table: "Guarantee");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Guarantee");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddress",
                table: "Delivery",
                newName: "Street");

            migrationBuilder.AddColumn<int>(
                name: "GuaranteeID",
                table: "Order",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Flat",
                table: "Delivery",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "House",
                table: "Delivery",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Order_GuaranteeID",
                table: "Order",
                column: "GuaranteeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Guarantee_GuaranteeID",
                table: "Order",
                column: "GuaranteeID",
                principalTable: "Guarantee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Guarantee_GuaranteeID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_GuaranteeID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "GuaranteeID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Flat",
                table: "Delivery");

            migrationBuilder.DropColumn(
                name: "House",
                table: "Delivery");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Delivery",
                newName: "DeliveryAddress");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Guarantee",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guarantee_OrderID",
                table: "Guarantee",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Guarantee_Order_OrderID",
                table: "Guarantee",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

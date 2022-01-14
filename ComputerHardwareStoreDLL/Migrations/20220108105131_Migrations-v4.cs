using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinKompTechnikiDLL.Migrations
{
    public partial class Migrationsv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_Order_OrderID",
                table: "Delivery");

            migrationBuilder.DropIndex(
                name: "IX_Delivery_OrderID",
                table: "Delivery");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Delivery");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryID",
                table: "Order",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryID",
                table: "Order",
                column: "DeliveryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Delivery_DeliveryID",
                table: "Order",
                column: "DeliveryID",
                principalTable: "Delivery",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Delivery_DeliveryID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DeliveryID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryID",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Delivery",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_OrderID",
                table: "Delivery",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Order_OrderID",
                table: "Delivery",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

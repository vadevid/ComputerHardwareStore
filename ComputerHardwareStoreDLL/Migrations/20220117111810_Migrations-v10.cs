using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinKompTechnikiDLL.Migrations
{
    public partial class Migrationsv10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeedForDelivery",
                table: "Delivery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NeedForDelivery",
                table: "Delivery",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}

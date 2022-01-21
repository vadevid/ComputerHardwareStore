using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinKompTechnikiDLL.Migrations
{
    public partial class Migrationsv7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Client",
                newName: "Street");

            migrationBuilder.AddColumn<int>(
                name: "Flat",
                table: "Client",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "House",
                table: "Client",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flat",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "House",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Client",
                newName: "Adress");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinKompTechnikiDLL.Migrations
{
    public partial class Migrationsv9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DurationOfTheGuarantee",
                table: "Guarantee",
                type: "text",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DurationOfTheGuarantee",
                table: "Guarantee",
                type: "interval",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}

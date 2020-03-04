using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodie.Data.Migrations
{
    public partial class DayDataUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "DayData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "DayData",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "DayData");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "DayData");
        }
    }
}

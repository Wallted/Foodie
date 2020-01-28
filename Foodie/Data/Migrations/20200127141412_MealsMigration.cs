using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodie.Data.Migrations
{
    public partial class MealsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Carbs",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsLiquid",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "KcalDemand",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Ingriedients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingriedients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingriedients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingriedients_ProductId",
                table: "Ingriedients",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingriedients");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsLiquid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "KcalDemand",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AspNetUsers");
        }
    }
}

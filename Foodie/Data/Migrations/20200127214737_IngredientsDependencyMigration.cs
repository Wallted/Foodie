using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodie.Data.Migrations
{
    public partial class IngredientsDependencyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Ingriedients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingriedients_MealId",
                table: "Ingriedients",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingriedients_Meals_MealId",
                table: "Ingriedients",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingriedients_Meals_MealId",
                table: "Ingriedients");

            migrationBuilder.DropIndex(
                name: "IX_Ingriedients_MealId",
                table: "Ingriedients");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Ingriedients");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodie.Data.Migrations
{
    public partial class DayDatasMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayData_AspNetUsers_UserId",
                table: "DayData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayData",
                table: "DayData");

            migrationBuilder.RenameTable(
                name: "DayData",
                newName: "DayDatas");

            migrationBuilder.RenameIndex(
                name: "IX_DayData_UserId",
                table: "DayDatas",
                newName: "IX_DayDatas_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayDatas",
                table: "DayDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayDatas_AspNetUsers_UserId",
                table: "DayDatas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayDatas_AspNetUsers_UserId",
                table: "DayDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayDatas",
                table: "DayDatas");

            migrationBuilder.RenameTable(
                name: "DayDatas",
                newName: "DayData");

            migrationBuilder.RenameIndex(
                name: "IX_DayDatas_UserId",
                table: "DayData",
                newName: "IX_DayData_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayData",
                table: "DayData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayData_AspNetUsers_UserId",
                table: "DayData",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

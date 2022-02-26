using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMobile.DAL.Migrations
{
    public partial class AddCurrencyProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CourseToDefault",
                table: "Currencies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CourseToDefault",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CourseToDefault",
                value: 1.95m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseToDefault",
                table: "Currencies");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMobile.DAL.Migrations
{
    public partial class AddedNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EurostandardId",
                table: "CarAds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Eurostandards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eurostandards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Eurostandards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Euro 1" },
                    { 2, "Euro 2" },
                    { 3, "Euro 3" },
                    { 4, "Euro 4" },
                    { 5, "Euro 5" },
                    { 6, "Euro 6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarAds_EurostandardId",
                table: "CarAds",
                column: "EurostandardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarAds_Eurostandards_EurostandardId",
                table: "CarAds",
                column: "EurostandardId",
                principalTable: "Eurostandards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarAds_Eurostandards_EurostandardId",
                table: "CarAds");

            migrationBuilder.DropTable(
                name: "Eurostandards");

            migrationBuilder.DropIndex(
                name: "IX_CarAds_EurostandardId",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "EurostandardId",
                table: "CarAds");
        }
    }
}

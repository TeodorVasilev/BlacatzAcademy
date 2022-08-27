using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMobile.DAL.Migrations
{
    public partial class AddPromotions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPromoted",
                table: "CarAds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PromoDuration",
                table: "CarAds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PromoEnd",
                table: "CarAds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PromoStart",
                table: "CarAds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PromotionId",
                table: "CarAds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "VIP" });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "TOP" });

            migrationBuilder.CreateIndex(
                name: "IX_CarAds_PromotionId",
                table: "CarAds",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarAds_Promotions_PromotionId",
                table: "CarAds",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarAds_Promotions_PromotionId",
                table: "CarAds");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_CarAds_PromotionId",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "IsPromoted",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "PromoDuration",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "PromoEnd",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "PromoStart",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "CarAds");
        }
    }
}

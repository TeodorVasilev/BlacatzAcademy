using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMobile.DAL.Migrations
{
    public partial class AddDateColumnsCarAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "CarAds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ManufactureMonth",
                table: "CarAds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManufactureYear",
                table: "CarAds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "ManufactureMonth",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "ManufactureYear",
                table: "CarAds");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMobile.DAL.Migrations
{
    public partial class UpdateListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "CarAds",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "CarAds");
        }
    }
}

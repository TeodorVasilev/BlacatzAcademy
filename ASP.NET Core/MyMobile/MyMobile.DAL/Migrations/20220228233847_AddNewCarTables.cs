using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMobile.DAL.Migrations
{
    public partial class AddNewCarTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comforts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comforts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interiors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interiors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Securities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Securities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarAdComforts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarAdId = table.Column<int>(type: "int", nullable: false),
                    ComfortId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAdComforts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarAdComforts_CarAds_CarAdId",
                        column: x => x.CarAdId,
                        principalTable: "CarAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarAdComforts_Comforts_ComfortId",
                        column: x => x.ComfortId,
                        principalTable: "Comforts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarAdInteriors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarAdId = table.Column<int>(type: "int", nullable: false),
                    InteriorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAdInteriors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarAdInteriors_CarAds_CarAdId",
                        column: x => x.CarAdId,
                        principalTable: "CarAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarAdInteriors_Interiors_InteriorId",
                        column: x => x.InteriorId,
                        principalTable: "Interiors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarAdSecurities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarAdId = table.Column<int>(type: "int", nullable: false),
                    SecurityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAdSecurities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarAdSecurities_CarAds_CarAdId",
                        column: x => x.CarAdId,
                        principalTable: "CarAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarAdSecurities_Securities_SecurityId",
                        column: x => x.SecurityId,
                        principalTable: "Securities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comforts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Навигация" },
                    { 2, "Темпомат" },
                    { 3, "Стерео уредба" },
                    { 4, "Подгряване на седалките" },
                    { 5, "Климатик" },
                    { 6, "Климатроник" }
                });

            migrationBuilder.InsertData(
                table: "Interiors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Кожен салон" },
                    { 2, "Велурен салон" },
                    { 3, "Десен волан" }
                });

            migrationBuilder.InsertData(
                table: "Securities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "GPS система за проследяване" },
                    { 2, "Автоматичен контрол на стабилността" },
                    { 3, "Антиблокираща система" },
                    { 4, "Въздушни възглавници" },
                    { 5, "Парктроник" },
                    { 6, "Система за защита от пробуксуване" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarAdComforts_CarAdId",
                table: "CarAdComforts",
                column: "CarAdId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAdComforts_ComfortId",
                table: "CarAdComforts",
                column: "ComfortId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAdInteriors_CarAdId",
                table: "CarAdInteriors",
                column: "CarAdId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAdInteriors_InteriorId",
                table: "CarAdInteriors",
                column: "InteriorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAdSecurities_CarAdId",
                table: "CarAdSecurities",
                column: "CarAdId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAdSecurities_SecurityId",
                table: "CarAdSecurities",
                column: "SecurityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarAdComforts");

            migrationBuilder.DropTable(
                name: "CarAdInteriors");

            migrationBuilder.DropTable(
                name: "CarAdSecurities");

            migrationBuilder.DropTable(
                name: "Comforts");

            migrationBuilder.DropTable(
                name: "Interiors");

            migrationBuilder.DropTable(
                name: "Securities");
        }
    }
}

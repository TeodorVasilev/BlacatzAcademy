using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMobile.DAL.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "CarAds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "CarAds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GearboxId",
                table: "CarAds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleCategoryId",
                table: "CarAds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gearboxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gearboxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCategories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Aвтомобили и джипове");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Бусове");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Камиони");

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Металик" },
                    { 2, "Черен" },
                    { 3, "Син" },
                    { 4, "Сив" },
                    { 5, "Бордо" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Бензинов" },
                    { 2, "Дизелов" },
                    { 3, "Електрически" },
                    { 4, "Хибриден" }
                });

            migrationBuilder.InsertData(
                table: "Gearboxes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Ръчна" },
                    { 2, "Автоматична" },
                    { 3, "Полуавтоматична" }
                });

            migrationBuilder.InsertData(
                table: "VehicleCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Седан" },
                    { 2, "Комби" },
                    { 3, "Стреч лимузина" },
                    { 4, "Джип" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarAds_ColorId",
                table: "CarAds",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAds_EngineId",
                table: "CarAds",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAds_GearboxId",
                table: "CarAds",
                column: "GearboxId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAds_VehicleCategoryId",
                table: "CarAds",
                column: "VehicleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarAds_Colors_ColorId",
                table: "CarAds",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarAds_Engines_EngineId",
                table: "CarAds",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarAds_Gearboxes_GearboxId",
                table: "CarAds",
                column: "GearboxId",
                principalTable: "Gearboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarAds_VehicleCategories_VehicleCategoryId",
                table: "CarAds",
                column: "VehicleCategoryId",
                principalTable: "VehicleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarAds_Colors_ColorId",
                table: "CarAds");

            migrationBuilder.DropForeignKey(
                name: "FK_CarAds_Engines_EngineId",
                table: "CarAds");

            migrationBuilder.DropForeignKey(
                name: "FK_CarAds_Gearboxes_GearboxId",
                table: "CarAds");

            migrationBuilder.DropForeignKey(
                name: "FK_CarAds_VehicleCategories_VehicleCategoryId",
                table: "CarAds");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Gearboxes");

            migrationBuilder.DropTable(
                name: "VehicleCategories");

            migrationBuilder.DropIndex(
                name: "IX_CarAds_ColorId",
                table: "CarAds");

            migrationBuilder.DropIndex(
                name: "IX_CarAds_EngineId",
                table: "CarAds");

            migrationBuilder.DropIndex(
                name: "IX_CarAds_GearboxId",
                table: "CarAds");

            migrationBuilder.DropIndex(
                name: "IX_CarAds_VehicleCategoryId",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "GearboxId",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "VehicleCategoryId",
                table: "CarAds");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Лек автомобил");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Джип");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Бус");
        }
    }
}

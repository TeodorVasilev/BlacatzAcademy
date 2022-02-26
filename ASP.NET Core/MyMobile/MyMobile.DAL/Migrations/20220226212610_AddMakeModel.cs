using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMobile.DAL.Migrations
{
    public partial class AddMakeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "CarAds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "CarAds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Бус" });

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Употребяван");

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Нов");

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "За части" });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Mercedes-Benz" },
                    { 3, "Opel" },
                    { 4, "Jeep" },
                    { 5, "Nissan" }
                });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Пловдив");

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Асеновград");

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Садово");

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Карлово");

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "MakeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "530" },
                    { 2, 1, "528" },
                    { 3, 2, "E 320" },
                    { 4, 2, "C 180" },
                    { 5, 3, "Vectra" },
                    { 6, 4, "Grand Cherokee" },
                    { 7, 5, "Patrol" },
                    { 8, 5, "Terano" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarAds_MakeId",
                table: "CarAds",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAds_ModelId",
                table: "CarAds",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarAds_Makes_MakeId",
                table: "CarAds",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarAds_Models_ModelId",
                table: "CarAds",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarAds_Makes_MakeId",
                table: "CarAds");

            migrationBuilder.DropForeignKey(
                name: "FK_CarAds_Models_ModelId",
                table: "CarAds");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Makes");

            migrationBuilder.DropIndex(
                name: "IX_CarAds_MakeId",
                table: "CarAds");

            migrationBuilder.DropIndex(
                name: "IX_CarAds_ModelId",
                table: "CarAds");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "CarAds");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "CarAds");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Jeep");

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Used");

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "New");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Plovdiv");

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Asenovgrad");

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Sadovo");

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Karlovo");
        }
    }
}

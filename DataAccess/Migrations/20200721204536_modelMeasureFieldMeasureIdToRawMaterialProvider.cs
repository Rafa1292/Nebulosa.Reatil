using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class modelMeasureFieldMeasureIdToRawMaterialProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_rawMaterials",
                table: "rawMaterials");

            migrationBuilder.RenameTable(
                name: "rawMaterials",
                newName: "RawMaterials");

            migrationBuilder.AddColumn<int>(
                name: "MeasureId",
                table: "RawMaterialProviders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RawMaterials",
                table: "RawMaterials",
                column: "RawMaterialId");

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    MeasureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.MeasureID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RawMaterials",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "MeasureId",
                table: "RawMaterialProviders");

            migrationBuilder.RenameTable(
                name: "RawMaterials",
                newName: "rawMaterials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rawMaterials",
                table: "rawMaterials",
                column: "RawMaterialId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class PreparationTableAndItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreparationItems",
                columns: table => new
                {
                    PreparationItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantiy = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    PreparationId = table.Column<int>(nullable: false),
                    MeasureId = table.Column<int>(nullable: false),
                    RawMaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreparationItems", x => x.PreparationItemId);
                });

            migrationBuilder.CreateTable(
                name: "Preparations",
                columns: table => new
                {
                    PreparationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preparations", x => x.PreparationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreparationItems");

            migrationBuilder.DropTable(
                name: "Preparations");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RawMaterialProviderBrandIdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeasureID",
                table: "Measures",
                newName: "MeasureId");

            migrationBuilder.AddColumn<int>(
                name: "RawMaterialProviderBrandId",
                table: "RawMaterialProviders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RawMaterialProviderBrands",
                columns: table => new
                {
                    RawMaterialProviderBrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RawMaterialProviderId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    UserCreate = table.Column<string>(nullable: true),
                    UserUpdate = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialProviderBrands", x => x.RawMaterialProviderBrandId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawMaterialProviderBrands");

            migrationBuilder.DropColumn(
                name: "RawMaterialProviderBrandId",
                table: "RawMaterialProviders");

            migrationBuilder.RenameColumn(
                name: "MeasureId",
                table: "Measures",
                newName: "MeasureID");
        }
    }
}

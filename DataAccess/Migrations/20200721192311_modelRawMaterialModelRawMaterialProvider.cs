using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class modelRawMaterialModelRawMaterialProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RawMaterialProviders",
                columns: table => new
                {
                    RawMaterialProviderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<int>(nullable: false),
                    RawMaterialId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    UserCreate = table.Column<string>(nullable: true),
                    UserUpdate = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialProviders", x => x.RawMaterialProviderId);
                });

            migrationBuilder.CreateTable(
                name: "rawMaterials",
                columns: table => new
                {
                    RawMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    LastPurchase = table.Column<DateTime>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    UserCreate = table.Column<string>(nullable: true),
                    UserUpdate = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rawMaterials", x => x.RawMaterialId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawMaterialProviders");

            migrationBuilder.DropTable(
                name: "rawMaterials");
        }
    }
}

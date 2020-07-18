using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addModelsRouteProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Account = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    RouteId = table.Column<int>(nullable: false),
                    PriceQuality = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    UserCreate = table.Column<string>(nullable: true),
                    UserUpdate = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lunes = table.Column<bool>(nullable: false),
                    Martes = table.Column<bool>(nullable: false),
                    Miercoles = table.Column<bool>(nullable: false),
                    Jueves = table.Column<bool>(nullable: false),
                    Viernes = table.Column<bool>(nullable: false),
                    Sabado = table.Column<bool>(nullable: false),
                    Domingo = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    UserCreate = table.Column<string>(nullable: true),
                    UserUpdate = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class TraceFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Measures",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "Measures",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Measures",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserCreate",
                table: "Measures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserUpdate",
                table: "Measures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Measures");

            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "Measures");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Measures");

            migrationBuilder.DropColumn(
                name: "UserCreate",
                table: "Measures");

            migrationBuilder.DropColumn(
                name: "UserUpdate",
                table: "Measures");
        }
    }
}

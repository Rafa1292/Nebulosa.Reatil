using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class securityFieldsOnModelPreparation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Preparations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "Preparations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Preparations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserCreate",
                table: "Preparations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserUpdate",
                table: "Preparations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "PreparationItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "PreparationItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "PreparationItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserCreate",
                table: "PreparationItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserUpdate",
                table: "PreparationItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Preparations");

            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "Preparations");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Preparations");

            migrationBuilder.DropColumn(
                name: "UserCreate",
                table: "Preparations");

            migrationBuilder.DropColumn(
                name: "UserUpdate",
                table: "Preparations");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "PreparationItems");

            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "PreparationItems");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "PreparationItems");

            migrationBuilder.DropColumn(
                name: "UserCreate",
                table: "PreparationItems");

            migrationBuilder.DropColumn(
                name: "UserUpdate",
                table: "PreparationItems");
        }
    }
}

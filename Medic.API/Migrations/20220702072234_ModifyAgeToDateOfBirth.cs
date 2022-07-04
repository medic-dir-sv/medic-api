using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medic.API.Migrations
{
    public partial class ModifyAgeToDateOfBirth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "BaseIdentities");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "BaseIdentities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "BaseIdentities");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "BaseIdentities",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Medic.API.Migrations
{
    public partial class FixSpecialtyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseIdentities_Speciality_SpecialtyId",
                table: "BaseIdentities");

            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImage",
                table: "BaseIdentities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BaseIdentities_Specialty_SpecialtyId",
                table: "BaseIdentities",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseIdentities_Specialty_SpecialtyId",
                table: "BaseIdentities");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImage",
                table: "BaseIdentities",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BaseIdentities_Speciality_SpecialtyId",
                table: "BaseIdentities",
                column: "SpecialtyId",
                principalTable: "Speciality",
                principalColumn: "Id");
        }
    }
}

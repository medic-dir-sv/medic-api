using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Medic.API.Migrations
{
    public partial class ModificationForSpecialtyToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseIdentities_Specialty_SpecialtyId",
                table: "BaseIdentities");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropIndex(
                name: "IX_BaseIdentities_SpecialtyId",
                table: "BaseIdentities");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "BaseIdentities");

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "BaseIdentities",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "BaseIdentities");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "BaseIdentities",
                type: "integer",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_BaseIdentities_SpecialtyId",
                table: "BaseIdentities",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseIdentities_Specialty_SpecialtyId",
                table: "BaseIdentities",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "Id");
        }
    }
}

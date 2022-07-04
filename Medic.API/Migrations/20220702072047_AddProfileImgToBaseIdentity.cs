using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medic.API.Migrations
{
    public partial class AddProfileImgToBaseIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "BaseIdentities",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "BaseIdentities");
        }
    }
}

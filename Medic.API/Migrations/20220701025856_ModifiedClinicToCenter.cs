using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medic.API.Migrations
{
    public partial class ModifiedClinicToCenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseIdentities_Experience_ExperienceId",
                table: "BaseIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseIdentities_Formation_FormationId",
                table: "BaseIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseIdentities_Schedule_ScheduleId",
                table: "BaseIdentities");

            migrationBuilder.DropIndex(
                name: "IX_BaseIdentities_ExperienceId",
                table: "BaseIdentities");

            migrationBuilder.DropIndex(
                name: "IX_BaseIdentities_FormationId",
                table: "BaseIdentities");

            migrationBuilder.DropIndex(
                name: "IX_BaseIdentities_ScheduleId",
                table: "BaseIdentities");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "BaseIdentities");

            migrationBuilder.DropColumn(
                name: "FormationId",
                table: "BaseIdentities");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "BaseIdentities");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Schedule",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Formation",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Experience",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_DoctorId",
                table: "Schedule",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Formation_DoctorId",
                table: "Formation",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_DoctorId",
                table: "Experience",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_BaseIdentities_DoctorId",
                table: "Experience",
                column: "DoctorId",
                principalTable: "BaseIdentities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Formation_BaseIdentities_DoctorId",
                table: "Formation",
                column: "DoctorId",
                principalTable: "BaseIdentities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_BaseIdentities_DoctorId",
                table: "Schedule",
                column: "DoctorId",
                principalTable: "BaseIdentities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experience_BaseIdentities_DoctorId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_Formation_BaseIdentities_DoctorId",
                table: "Formation");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_BaseIdentities_DoctorId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_DoctorId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Formation_DoctorId",
                table: "Formation");

            migrationBuilder.DropIndex(
                name: "IX_Experience_DoctorId",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Formation");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Experience");

            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "BaseIdentities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormationId",
                table: "BaseIdentities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "BaseIdentities",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseIdentities_ExperienceId",
                table: "BaseIdentities",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseIdentities_FormationId",
                table: "BaseIdentities",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseIdentities_ScheduleId",
                table: "BaseIdentities",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseIdentities_Experience_ExperienceId",
                table: "BaseIdentities",
                column: "ExperienceId",
                principalTable: "Experience",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseIdentities_Formation_FormationId",
                table: "BaseIdentities",
                column: "FormationId",
                principalTable: "Formation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseIdentities_Schedule_ScheduleId",
                table: "BaseIdentities",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id");
        }
    }
}

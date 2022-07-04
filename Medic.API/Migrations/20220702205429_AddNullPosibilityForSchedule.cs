using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medic.API.Migrations
{
    public partial class AddNullPosibilityForSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseIdentities_Schedule_ScheduleId",
                table: "BaseIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_Workday_Schedule_ScheduleId",
                table: "Workday");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseIdentities_Schedules_ScheduleId",
                table: "BaseIdentities",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workday_Schedules_ScheduleId",
                table: "Workday",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseIdentities_Schedules_ScheduleId",
                table: "BaseIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_Workday_Schedules_ScheduleId",
                table: "Workday");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseIdentities_Schedule_ScheduleId",
                table: "BaseIdentities",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workday_Schedule_ScheduleId",
                table: "Workday",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id");
        }
    }
}

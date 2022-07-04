using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Medic.API.Migrations
{
    public partial class FixScheduleToSingleInstance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_BaseIdentities_DoctorId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_DoctorId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Schedule");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "BaseIdentities",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: true),
                    DoctorId = table.Column<int>(type: "integer", nullable: true),
                    IsAccepted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_BaseIdentities_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "BaseIdentities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_BaseIdentities_PatientId",
                        column: x => x.PatientId,
                        principalTable: "BaseIdentities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseIdentities_ScheduleId",
                table: "BaseIdentities",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseIdentities_Schedule_ScheduleId",
                table: "BaseIdentities",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseIdentities_Schedule_ScheduleId",
                table: "BaseIdentities");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_BaseIdentities_ScheduleId",
                table: "BaseIdentities");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "BaseIdentities");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Schedule",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_DoctorId",
                table: "Schedule",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_BaseIdentities_DoctorId",
                table: "Schedule",
                column: "DoctorId",
                principalTable: "BaseIdentities",
                principalColumn: "Id");
        }
    }
}

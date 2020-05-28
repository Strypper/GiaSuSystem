using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class Version119 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestSchedules");

            migrationBuilder.AddColumn<string>(
                name: "TitleColor",
                table: "StudyGroups",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestSubjectSchedules",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekDay = table.Column<string>(nullable: false),
                    TimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    RequestSubjectRequestID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSubjectSchedules", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_RequestSubjectSchedules_RequestSubjects_RequestSubjectRequestID",
                        column: x => x.RequestSubjectRequestID,
                        principalTable: "RequestSubjects",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestSubjectSchedules_RequestSubjectRequestID",
                table: "RequestSubjectSchedules",
                column: "RequestSubjectRequestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestSubjectSchedules");

            migrationBuilder.DropColumn(
                name: "TitleColor",
                table: "StudyGroups");

            migrationBuilder.CreateTable(
                name: "RequestSchedules",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestSubjectRequestID = table.Column<int>(type: "int", nullable: true),
                    TimeEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    WeekDay = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSchedules", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_RequestSchedules_RequestSubjects_RequestSubjectRequestID",
                        column: x => x.RequestSubjectRequestID,
                        principalTable: "RequestSubjects",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestSchedules_RequestSubjectRequestID",
                table: "RequestSchedules",
                column: "RequestSubjectRequestID");
        }
    }
}

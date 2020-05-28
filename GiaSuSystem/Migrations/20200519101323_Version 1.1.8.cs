using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class Version118 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WeekDay",
                table: "RequestSchedules",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestSubjectRequestID",
                table: "RequestSchedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestSchedules_RequestSubjectRequestID",
                table: "RequestSchedules",
                column: "RequestSubjectRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSchedules_RequestSubjects_RequestSubjectRequestID",
                table: "RequestSchedules",
                column: "RequestSubjectRequestID",
                principalTable: "RequestSubjects",
                principalColumn: "RequestID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSchedules_RequestSubjects_RequestSubjectRequestID",
                table: "RequestSchedules");

            migrationBuilder.DropIndex(
                name: "IX_RequestSchedules_RequestSubjectRequestID",
                table: "RequestSchedules");

            migrationBuilder.DropColumn(
                name: "RequestSubjectRequestID",
                table: "RequestSchedules");

            migrationBuilder.AlterColumn<string>(
                name: "WeekDay",
                table: "RequestSchedules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}

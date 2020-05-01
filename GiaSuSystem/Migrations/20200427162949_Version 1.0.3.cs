using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class Version103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSubjects_Schools_SchoolID",
                table: "RequestSubjects");

            migrationBuilder.DropIndex(
                name: "IX_RequestSubjects_SchoolID",
                table: "RequestSubjects");

            migrationBuilder.DropColumn(
                name: "SchoolID",
                table: "RequestSubjects");

            migrationBuilder.AddColumn<int>(
                name: "SchoolSubject",
                table: "RequestSubjects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolSubject",
                table: "RequestSubjects");

            migrationBuilder.AddColumn<int>(
                name: "SchoolID",
                table: "RequestSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RequestSubjects_SchoolID",
                table: "RequestSubjects",
                column: "SchoolID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSubjects_Schools_SchoolID",
                table: "RequestSubjects",
                column: "SchoolID",
                principalTable: "Schools",
                principalColumn: "SchoolID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

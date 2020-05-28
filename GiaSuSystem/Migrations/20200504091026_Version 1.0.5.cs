using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class Version105 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Schools_SchoolID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SchoolID",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SchoolSubject",
                table: "RequestSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolID",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SchoolID",
                table: "Subjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SchoolSubject",
                table: "RequestSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SchoolID",
                table: "Subjects",
                column: "SchoolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Schools_SchoolID",
                table: "Subjects",
                column: "SchoolID",
                principalTable: "Schools",
                principalColumn: "SchoolID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

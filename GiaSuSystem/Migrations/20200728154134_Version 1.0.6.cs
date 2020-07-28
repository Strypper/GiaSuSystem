using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class Version106 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StudyGroupID",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudyFieldID",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudyFieldID",
                table: "AspNetUsers",
                column: "StudyFieldID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudyGroupID",
                table: "AspNetUsers",
                column: "StudyGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StudyFields_StudyFieldID",
                table: "AspNetUsers",
                column: "StudyFieldID",
                principalTable: "StudyFields",
                principalColumn: "StudyFieldID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StudyGroups_StudyGroupID",
                table: "AspNetUsers",
                column: "StudyGroupID",
                principalTable: "StudyGroups",
                principalColumn: "StudyGroupID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StudyFields_StudyFieldID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StudyGroups_StudyGroupID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudyFieldID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudyGroupID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "StudyGroupID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudyFieldID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}

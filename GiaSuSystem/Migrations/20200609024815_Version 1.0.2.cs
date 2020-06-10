using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class Version102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedbackHubs_AspNetUsers_OwnerId",
                table: "FeedbackHubs");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "FeedbackHubs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackHubs_AspNetUsers_OwnerId",
                table: "FeedbackHubs",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedbackHubs_AspNetUsers_OwnerId",
                table: "FeedbackHubs");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "FeedbackHubs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackHubs_AspNetUsers_OwnerId",
                table: "FeedbackHubs",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

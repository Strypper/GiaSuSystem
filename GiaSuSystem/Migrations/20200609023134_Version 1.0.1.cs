using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class Version101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedbackHubs",
                columns: table => new
                {
                    IssueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Platform = table.Column<string>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    TimeUpload = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackHubs", x => x.IssueID);
                    table.ForeignKey(
                        name: "FK_FeedbackHubs_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackHubs_OwnerId",
                table: "FeedbackHubs",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackHubs");
        }
    }
}

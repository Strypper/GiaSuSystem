using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class SchoolModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "School",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "School",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "SchoolID",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Teacher",
                table: "Subjects",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolID",
                table: "RequestSubjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SchoolAddress = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SchoolLogo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SchoolID",
                table: "Subjects",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSubjects_SchoolID",
                table: "RequestSubjects",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SchoolID",
                table: "AspNetUsers",
                column: "SchoolID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Schools_SchoolID",
                table: "AspNetUsers",
                column: "SchoolID",
                principalTable: "Schools",
                principalColumn: "SchoolID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSubjects_Schools_SchoolID",
                table: "RequestSubjects",
                column: "SchoolID",
                principalTable: "Schools",
                principalColumn: "SchoolID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Schools_SchoolID",
                table: "Subjects",
                column: "SchoolID",
                principalTable: "Schools",
                principalColumn: "SchoolID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Schools_SchoolID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSubjects_Schools_SchoolID",
                table: "RequestSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Schools_SchoolID",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SchoolID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_RequestSubjects_SchoolID",
                table: "RequestSubjects");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SchoolID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolID",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Teacher",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SchoolID",
                table: "RequestSubjects");

            migrationBuilder.DropColumn(
                name: "SchoolID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "Subjects",
                type: "nvarchar(70)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                nullable: true);
        }
    }
}

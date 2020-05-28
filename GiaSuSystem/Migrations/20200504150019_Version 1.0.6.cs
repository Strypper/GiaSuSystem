using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class Version106 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudyFieldID",
                table: "Subjects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudyGroupID",
                table: "Subjects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StudyFields",
                columns: table => new
                {
                    StudyFieldID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyGroupID = table.Column<int>(nullable: false),
                    StudyFieldName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyFields", x => x.StudyFieldID);
                });

            migrationBuilder.CreateTable(
                name: "StudyGroups",
                columns: table => new
                {
                    StudyGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyGroups", x => x.StudyGroupID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyFields");

            migrationBuilder.DropTable(
                name: "StudyGroups");

            migrationBuilder.DropColumn(
                name: "StudyFieldID",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "StudyGroupID",
                table: "Subjects");
        }
    }
}

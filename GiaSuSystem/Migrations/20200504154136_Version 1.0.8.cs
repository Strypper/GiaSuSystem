using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class Version108 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeWork",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Laboratory",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Presentation",
                table: "Subjects");

            migrationBuilder.AddColumn<bool>(
                name: "HomeWork",
                table: "RequestSubjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Laboratory",
                table: "RequestSubjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Presentation",
                table: "RequestSubjects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeWork",
                table: "RequestSubjects");

            migrationBuilder.DropColumn(
                name: "Laboratory",
                table: "RequestSubjects");

            migrationBuilder.DropColumn(
                name: "Presentation",
                table: "RequestSubjects");

            migrationBuilder.AddColumn<bool>(
                name: "HomeWork",
                table: "Subjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Laboratory",
                table: "Subjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Presentation",
                table: "Subjects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

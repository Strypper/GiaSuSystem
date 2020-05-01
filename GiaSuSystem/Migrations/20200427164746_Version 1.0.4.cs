using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class Version104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSubjects_Locations_LocationAddressLocationId",
                table: "RequestSubjects");

            migrationBuilder.DropIndex(
                name: "IX_RequestSubjects_LocationAddressLocationId",
                table: "RequestSubjects");

            migrationBuilder.DropColumn(
                name: "LocationAddressLocationId",
                table: "RequestSubjects");

            migrationBuilder.AddColumn<string>(
                name: "LearningAddress",
                table: "RequestSubjects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LearningCity",
                table: "RequestSubjects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LearningDistrict",
                table: "RequestSubjects",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LearningAddress",
                table: "RequestSubjects");

            migrationBuilder.DropColumn(
                name: "LearningCity",
                table: "RequestSubjects");

            migrationBuilder.DropColumn(
                name: "LearningDistrict",
                table: "RequestSubjects");

            migrationBuilder.AddColumn<int>(
                name: "LocationAddressLocationId",
                table: "RequestSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RequestSubjects_LocationAddressLocationId",
                table: "RequestSubjects",
                column: "LocationAddressLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSubjects_Locations_LocationAddressLocationId",
                table: "RequestSubjects",
                column: "LocationAddressLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

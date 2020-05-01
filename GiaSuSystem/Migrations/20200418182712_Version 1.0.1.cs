using Microsoft.EntityFrameworkCore.Migrations;

namespace GiaSuSystem.Migrations
{
    public partial class Version101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Schools_SchoolID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SchoolID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "AspNetUsers",
                newName: "UserDistrict");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "AspNetUsers",
                newName: "UserCity");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "UserAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserDistrict",
                table: "AspNetUsers",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "UserCity",
                table: "AspNetUsers",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "UserAddress",
                table: "AspNetUsers",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "SchoolID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
        }
    }
}

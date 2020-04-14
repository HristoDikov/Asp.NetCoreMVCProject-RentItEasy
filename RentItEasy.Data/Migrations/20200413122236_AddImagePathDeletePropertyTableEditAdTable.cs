using Microsoft.EntityFrameworkCore.Migrations;

namespace RentItEasy.Data.Migrations
{
    public partial class AddImagePathDeletePropertyTableEditAdTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "ImagesPaths");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ImagesPaths");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgencyId",
                table: "ImagesPaths",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ImagesPaths",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

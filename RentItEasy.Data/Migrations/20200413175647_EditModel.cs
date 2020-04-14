using Microsoft.EntityFrameworkCore.Migrations;

namespace RentItEasy.Data.Migrations
{
    public partial class EditModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "ImagesPaths",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "ImagesPaths");
        }
    }
}

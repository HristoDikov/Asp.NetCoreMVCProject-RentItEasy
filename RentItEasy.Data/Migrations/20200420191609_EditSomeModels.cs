using Microsoft.EntityFrameworkCore.Migrations;

namespace RentItEasy.Data.Migrations
{
    public partial class EditSomeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "Ratings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AgenciesProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AgenciesProfiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AgenciesProfiles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AgenciesProfiles");
        }
    }
}

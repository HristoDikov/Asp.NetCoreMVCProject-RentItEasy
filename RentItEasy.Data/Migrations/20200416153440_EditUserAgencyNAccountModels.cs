using Microsoft.EntityFrameworkCore.Migrations;

namespace RentItEasy.Data.Migrations
{
    public partial class EditUserAgencyNAccountModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "UsersProfiles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUserProfile",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "AgenciesProfiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "IsUserProfile",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "AgenciesProfiles");
        }
    }
}

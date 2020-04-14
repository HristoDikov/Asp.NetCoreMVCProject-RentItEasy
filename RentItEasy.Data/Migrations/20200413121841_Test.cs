using Microsoft.EntityFrameworkCore.Migrations;

namespace RentItEasy.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgencyId",
                table: "ImagesPaths",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgencyProfileId",
                table: "ImagesPaths",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ImagesPaths",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserProfileId",
                table: "ImagesPaths",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagesPaths_AgencyProfileId",
                table: "ImagesPaths",
                column: "AgencyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesPaths_UserProfileId",
                table: "ImagesPaths",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesPaths_AgenciesProfiles_AgencyProfileId",
                table: "ImagesPaths",
                column: "AgencyProfileId",
                principalTable: "AgenciesProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesPaths_UsersProfiles_UserProfileId",
                table: "ImagesPaths",
                column: "UserProfileId",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesPaths_AgenciesProfiles_AgencyProfileId",
                table: "ImagesPaths");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesPaths_UsersProfiles_UserProfileId",
                table: "ImagesPaths");

            migrationBuilder.DropIndex(
                name: "IX_ImagesPaths_AgencyProfileId",
                table: "ImagesPaths");

            migrationBuilder.DropIndex(
                name: "IX_ImagesPaths_UserProfileId",
                table: "ImagesPaths");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "ImagesPaths");

            migrationBuilder.DropColumn(
                name: "AgencyProfileId",
                table: "ImagesPaths");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ImagesPaths");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "ImagesPaths");
        }
    }
}

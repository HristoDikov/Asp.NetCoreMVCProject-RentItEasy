using Microsoft.EntityFrameworkCore.Migrations;

namespace RentItEasy.Data.Migrations
{
    public partial class FixImagePathModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagePath_Ads_AdId",
                table: "ImagePath");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagePath_AgenciesProfiles_AgencyProfileId",
                table: "ImagePath");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagePath_UsersProfiles_UserProfileId",
                table: "ImagePath");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagePath",
                table: "ImagePath");

            migrationBuilder.DropIndex(
                name: "IX_ImagePath_AgencyProfileId",
                table: "ImagePath");

            migrationBuilder.DropIndex(
                name: "IX_ImagePath_UserProfileId",
                table: "ImagePath");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "ImagePath");

            migrationBuilder.DropColumn(
                name: "AgencyProfileId",
                table: "ImagePath");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ImagePath");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "ImagePath");

            migrationBuilder.RenameTable(
                name: "ImagePath",
                newName: "ImagesPaths");

            migrationBuilder.RenameIndex(
                name: "IX_ImagePath_AdId",
                table: "ImagesPaths",
                newName: "IX_ImagesPaths_AdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesPaths",
                table: "ImagesPaths",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesPaths_Ads_AdId",
                table: "ImagesPaths",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesPaths_Ads_AdId",
                table: "ImagesPaths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesPaths",
                table: "ImagesPaths");

            migrationBuilder.RenameTable(
                name: "ImagesPaths",
                newName: "ImagePath");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesPaths_AdId",
                table: "ImagePath",
                newName: "IX_ImagePath_AdId");

            migrationBuilder.AddColumn<string>(
                name: "AgencyId",
                table: "ImagePath",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgencyProfileId",
                table: "ImagePath",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ImagePath",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserProfileId",
                table: "ImagePath",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagePath",
                table: "ImagePath",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ImagePath_AgencyProfileId",
                table: "ImagePath",
                column: "AgencyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagePath_UserProfileId",
                table: "ImagePath",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagePath_Ads_AdId",
                table: "ImagePath",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagePath_AgenciesProfiles_AgencyProfileId",
                table: "ImagePath",
                column: "AgencyProfileId",
                principalTable: "AgenciesProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagePath_UsersProfiles_UserProfileId",
                table: "ImagePath",
                column: "UserProfileId",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

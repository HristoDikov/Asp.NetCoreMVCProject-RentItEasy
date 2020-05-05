using Microsoft.EntityFrameworkCore.Migrations;

namespace RentItEasy.Data.Migrations
{
    public partial class EditModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgencyProfileId",
                table: "UsersRatings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersRatings_AgencyProfileId",
                table: "UsersRatings",
                column: "AgencyProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRatings_AgenciesProfiles_AgencyProfileId",
                table: "UsersRatings",
                column: "AgencyProfileId",
                principalTable: "AgenciesProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRatings_AgenciesProfiles_AgencyProfileId",
                table: "UsersRatings");

            migrationBuilder.DropIndex(
                name: "IX_UsersRatings_AgencyProfileId",
                table: "UsersRatings");

            migrationBuilder.DropColumn(
                name: "AgencyProfileId",
                table: "UsersRatings");
        }
    }
}

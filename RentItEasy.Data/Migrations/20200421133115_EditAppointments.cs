using Microsoft.EntityFrameworkCore.Migrations;

namespace RentItEasy.Data.Migrations
{
    public partial class EditAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_Ratings_RatingId",
                table: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UsersProfiles_RatingId",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "UsersProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RatingId",
                table: "UsersProfiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_RatingId",
                table: "UsersProfiles",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_Ratings_RatingId",
                table: "UsersProfiles",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

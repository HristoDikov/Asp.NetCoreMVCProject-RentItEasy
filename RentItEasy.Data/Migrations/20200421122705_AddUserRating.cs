using Microsoft.EntityFrameworkCore.Migrations;

namespace RentItEasy.Data.Migrations
{
    public partial class AddUserRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersRatings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserProfileId = table.Column<string>(nullable: true),
                    RatingId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersRatings_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRatings_UsersProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UsersProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRatings_RatingId",
                table: "UsersRatings",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRatings_UserProfileId",
                table: "UsersRatings",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRatings");
        }
    }
}

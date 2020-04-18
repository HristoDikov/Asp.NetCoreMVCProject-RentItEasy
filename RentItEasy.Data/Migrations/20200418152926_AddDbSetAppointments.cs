using Microsoft.EntityFrameworkCore.Migrations;

namespace RentItEasy.Data.Migrations
{
    public partial class AddDbSetAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Ads_AdId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AgenciesProfiles_AgencyProfileId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_UsersProfiles_UserProfileId",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_UserProfileId",
                table: "Appointments",
                newName: "IX_Appointments_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_AgencyProfileId",
                table: "Appointments",
                newName: "IX_Appointments_AgencyProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_AdId",
                table: "Appointments",
                newName: "IX_Appointments_AdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Ads_AdId",
                table: "Appointments",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AgenciesProfiles_AgencyProfileId",
                table: "Appointments",
                column: "AgencyProfileId",
                principalTable: "AgenciesProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_UsersProfiles_UserProfileId",
                table: "Appointments",
                column: "UserProfileId",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Ads_AdId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AgenciesProfiles_AgencyProfileId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_UsersProfiles_UserProfileId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserProfileId",
                table: "Appointment",
                newName: "IX_Appointment_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_AgencyProfileId",
                table: "Appointment",
                newName: "IX_Appointment_AgencyProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_AdId",
                table: "Appointment",
                newName: "IX_Appointment_AdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Ads_AdId",
                table: "Appointment",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AgenciesProfiles_AgencyProfileId",
                table: "Appointment",
                column: "AgencyProfileId",
                principalTable: "AgenciesProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_UsersProfiles_UserProfileId",
                table: "Appointment",
                column: "UserProfileId",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

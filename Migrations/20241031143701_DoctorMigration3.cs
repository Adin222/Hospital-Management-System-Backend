using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class DoctorMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Doctors",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                newName: "IX_Doctors_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_UserID",
                table: "Doctors",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_UserID",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Doctors",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_UserID",
                table: "Doctors",
                newName: "IX_Doctors_UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

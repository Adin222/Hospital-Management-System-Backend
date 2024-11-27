using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class NewestMigrationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "MedicalRecords",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "MedicalRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "MedicalRecords",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}

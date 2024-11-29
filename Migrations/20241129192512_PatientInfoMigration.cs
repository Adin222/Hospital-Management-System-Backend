using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hospital_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class PatientInfoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AllergyName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergyId);
                });

            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    IllnessId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IllnessName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.IllnessId);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicationName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationId);
                });

            migrationBuilder.CreateTable(
                name: "AllergyPatient",
                columns: table => new
                {
                    AllergiesAllergyId = table.Column<int>(type: "integer", nullable: false),
                    PatientAllergiesPatientID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyPatient", x => new { x.AllergiesAllergyId, x.PatientAllergiesPatientID });
                    table.ForeignKey(
                        name: "FK_AllergyPatient_Allergies_AllergiesAllergyId",
                        column: x => x.AllergiesAllergyId,
                        principalTable: "Allergies",
                        principalColumn: "AllergyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergyPatient_Patients_PatientAllergiesPatientID",
                        column: x => x.PatientAllergiesPatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IllnessPatient",
                columns: table => new
                {
                    IllnessesIllnessId = table.Column<int>(type: "integer", nullable: false),
                    PatientIllnessesPatientID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IllnessPatient", x => new { x.IllnessesIllnessId, x.PatientIllnessesPatientID });
                    table.ForeignKey(
                        name: "FK_IllnessPatient_Illnesses_IllnessesIllnessId",
                        column: x => x.IllnessesIllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "IllnessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IllnessPatient_Patients_PatientIllnessesPatientID",
                        column: x => x.PatientIllnessesPatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationPatient",
                columns: table => new
                {
                    MedicationsMedicationId = table.Column<int>(type: "integer", nullable: false),
                    PatientMedicationsPatientID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationPatient", x => new { x.MedicationsMedicationId, x.PatientMedicationsPatientID });
                    table.ForeignKey(
                        name: "FK_MedicationPatient_Medications_MedicationsMedicationId",
                        column: x => x.MedicationsMedicationId,
                        principalTable: "Medications",
                        principalColumn: "MedicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationPatient_Patients_PatientMedicationsPatientID",
                        column: x => x.PatientMedicationsPatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergyPatient_PatientAllergiesPatientID",
                table: "AllergyPatient",
                column: "PatientAllergiesPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_IllnessPatient_PatientIllnessesPatientID",
                table: "IllnessPatient",
                column: "PatientIllnessesPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPatient_PatientMedicationsPatientID",
                table: "MedicationPatient",
                column: "PatientMedicationsPatientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergyPatient");

            migrationBuilder.DropTable(
                name: "IllnessPatient");

            migrationBuilder.DropTable(
                name: "MedicationPatient");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "Medications");
        }
    }
}

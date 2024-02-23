using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelBD_API.Migrations
{
    /// <inheritdoc />
    public partial class DiseaseInfoChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiseaseInformationId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiseaseInformationId",
                table: "Patients",
                column: "DiseaseInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_DiseaseInformations_DiseaseInformationId",
                table: "Patients",
                column: "DiseaseInformationId",
                principalTable: "DiseaseInformations",
                principalColumn: "DiseaseInformationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_DiseaseInformations_DiseaseInformationId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DiseaseInformationId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DiseaseInformationId",
                table: "Patients");
        }
    }
}

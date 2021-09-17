using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagement.Data.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserPatientRelations",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "UserPatientRelations",
                newName: "PatientName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserPatientRelations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PatientName",
                table: "UserPatientRelations",
                newName: "PatientId");
        }
    }
}

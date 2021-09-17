using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagement.Data.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelationId",
                table: "UserPatientRelations",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserPatientRelations",
                newName: "RelationId");
        }
    }
}

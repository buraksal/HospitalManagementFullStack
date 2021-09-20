using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagement.Data.Migrations
{
    public partial class Seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complaint",
                table: "UserPatientRelations");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "UserPatientRelations");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserPatientRelations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Patients");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "UserPatientRelations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserPatientRelations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPatientRelations_PatientId",
                table: "UserPatientRelations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPatientRelations_UserId",
                table: "UserPatientRelations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CreatedById",
                table: "Patients",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_CreatedById",
                table: "Patients",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPatientRelations_Patients_PatientId",
                table: "UserPatientRelations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPatientRelations_Users_UserId",
                table: "UserPatientRelations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_CreatedById",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPatientRelations_Patients_PatientId",
                table: "UserPatientRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPatientRelations_Users_UserId",
                table: "UserPatientRelations");

            migrationBuilder.DropIndex(
                name: "IX_UserPatientRelations_PatientId",
                table: "UserPatientRelations");

            migrationBuilder.DropIndex(
                name: "IX_UserPatientRelations_UserId",
                table: "UserPatientRelations");

            migrationBuilder.DropIndex(
                name: "IX_Patients_CreatedById",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "UserPatientRelations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserPatientRelations");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "Complaint",
                table: "UserPatientRelations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "UserPatientRelations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserPatientRelations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPharmacyManagementSystem.Data.Migrations
{
    public partial class DrugPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_AspNetUsers_AppUserId",
                table: "Drugs");

            migrationBuilder.DropIndex(
                name: "IX_Drugs_AppUserId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Drugs");

            migrationBuilder.CreateTable(
                name: "AppUserDrug",
                columns: table => new
                {
                    PatientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserDrug", x => new { x.PatientsId, x.PrescriptionsId });
                    table.ForeignKey(
                        name: "FK_AppUserDrug_AspNetUsers_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserDrug_Drugs_PrescriptionsId",
                        column: x => x.PrescriptionsId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDrug_PrescriptionsId",
                table: "AppUserDrug",
                column: "PrescriptionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserDrug");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Drugs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_AppUserId",
                table: "Drugs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_AspNetUsers_AppUserId",
                table: "Drugs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

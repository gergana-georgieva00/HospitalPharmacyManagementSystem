using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPharmacyManagementSystem.Data.Migrations
{
    public partial class UpdatedDrugEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_AspNetUsers_PatientId",
                table: "Drugs");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Drugs",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Drugs_PatientId",
                table: "Drugs",
                newName: "IX_Drugs_AppUserId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Over-the-counter" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Prescription" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Complementary medicine" });

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_AspNetUsers_AppUserId",
                table: "Drugs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_AspNetUsers_AppUserId",
                table: "Drugs");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Drugs",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Drugs_AppUserId",
                table: "Drugs",
                newName: "IX_Drugs_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_AspNetUsers_PatientId",
                table: "Drugs",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

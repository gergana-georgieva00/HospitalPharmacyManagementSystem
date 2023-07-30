using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPharmacyManagementSystem.Data.Migrations
{
    public partial class NewClassPrescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserDrug");

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("2ab7157e-1add-40bc-9c32-87a194cb314d"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("56c779c4-c548-4251-8f48-1493f834c1a6"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("74c548fc-90b6-4479-8b12-8a14d8a39ccb"));

            migrationBuilder.AddColumn<Guid>(
                name: "DrugId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "PharmacistId", "Price" },
                values: new object[] { new Guid("1d4d943b-8184-459a-9915-8f2dfb26def9"), "Advil", 1, "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", new Guid("1b65aad4-f701-4209-84db-746688809c34"), 15.92m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "PharmacistId", "Price" },
                values: new object[] { new Guid("25a2e808-09e1-4b3f-98d1-8e631a8df075"), "Lipitor", 2, "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", new Guid("1b65aad4-f701-4209-84db-746688809c34"), 20.71m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "PharmacistId", "Price" },
                values: new object[] { new Guid("2ed3c3cc-1f94-4785-a1a7-14c98cb6cf51"), "Nature Made Fish Oil", 3, "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", new Guid("1b65aad4-f701-4209-84db-746688809c34"), 24.99m });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DrugId",
                table: "AspNetUsers",
                column: "DrugId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Drugs_DrugId",
                table: "AspNetUsers",
                column: "DrugId",
                principalTable: "Drugs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Drugs_DrugId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DrugId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("1d4d943b-8184-459a-9915-8f2dfb26def9"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("25a2e808-09e1-4b3f-98d1-8e631a8df075"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("2ed3c3cc-1f94-4785-a1a7-14c98cb6cf51"));

            migrationBuilder.DropColumn(
                name: "DrugId",
                table: "AspNetUsers");

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

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "PharmacistId", "Price" },
                values: new object[] { new Guid("2ab7157e-1add-40bc-9c32-87a194cb314d"), "Lipitor", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", false, new Guid("1b65aad4-f701-4209-84db-746688809c34"), 20.71m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "PharmacistId", "Price" },
                values: new object[] { new Guid("56c779c4-c548-4251-8f48-1493f834c1a6"), "Nature Made Fish Oil", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", false, new Guid("1b65aad4-f701-4209-84db-746688809c34"), 24.99m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "PharmacistId", "Price" },
                values: new object[] { new Guid("74c548fc-90b6-4479-8b12-8a14d8a39ccb"), "Advil", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", false, new Guid("1b65aad4-f701-4209-84db-746688809c34"), 15.92m });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDrug_PrescriptionsId",
                table: "AppUserDrug",
                column: "PrescriptionsId");
        }
    }
}

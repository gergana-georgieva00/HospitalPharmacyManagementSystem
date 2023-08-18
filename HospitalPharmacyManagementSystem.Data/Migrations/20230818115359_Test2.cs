using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPharmacyManagementSystem.Data.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("29a57f64-0b75-4061-b873-8ca12889424b"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("3405177d-8232-4671-ad99-853353810192"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("ae134e70-9518-4409-805d-85696c3be119"));

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "Price" },
                values: new object[] { new Guid("22ea0d0b-4f8e-4ae7-b3fe-9a27ccbe69c9"), "Lipitor", 2, "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", 20.71m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "Price" },
                values: new object[] { new Guid("811f232a-f0d6-40c0-b8a4-5def2f8802ef"), "Nature Made Fish Oil", 3, "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", 24.99m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "Price" },
                values: new object[] { new Guid("b6bfcfc8-0021-4f60-bf5e-c8775d2a1ec5"), "Advil", 1, "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", 15.92m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("22ea0d0b-4f8e-4ae7-b3fe-9a27ccbe69c9"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("811f232a-f0d6-40c0-b8a4-5def2f8802ef"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("b6bfcfc8-0021-4f60-bf5e-c8775d2a1ec5"));

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("29a57f64-0b75-4061-b873-8ca12889424b"), "Advil", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", false, 15.92m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("3405177d-8232-4671-ad99-853353810192"), "Nature Made Fish Oil", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", false, 24.99m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("ae134e70-9518-4409-805d-85696c3be119"), "Lipitor", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", false, 20.71m });
        }
    }
}

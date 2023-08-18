using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPharmacyManagementSystem.Data.Migrations
{
    public partial class SeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Diseases",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Heart Disease" },
                    { 2, "Skin Cancer" },
                    { 3, "Obesity" },
                    { 4, "Chronic Respiratory Disease" },
                    { 5, "Type two Diabetes" },
                    { 6, "Influenza" }
                });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "Price" },
                values: new object[,]
                {
                    { new Guid("88ed9f27-1595-455e-a0a2-ea04e71abed7"), "Advil", 1, "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", 15.92m },
                    { new Guid("cca8f7a9-a59c-465b-a439-979d72ae14a0"), "Nature Made Fish Oil", 3, "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", 24.99m },
                    { new Guid("e395d97a-61da-4913-839d-dcae4c774174"), "Lipitor", 2, "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", 20.71m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("88ed9f27-1595-455e-a0a2-ea04e71abed7"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("cca8f7a9-a59c-465b-a439-979d72ae14a0"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("e395d97a-61da-4913-839d-dcae4c774174"));

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("22ea0d0b-4f8e-4ae7-b3fe-9a27ccbe69c9"), "Lipitor", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", false, 20.71m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("811f232a-f0d6-40c0-b8a4-5def2f8802ef"), "Nature Made Fish Oil", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", false, 24.99m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("b6bfcfc8-0021-4f60-bf5e-c8775d2a1ec5"), "Advil", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", false, 15.92m });
        }
    }
}

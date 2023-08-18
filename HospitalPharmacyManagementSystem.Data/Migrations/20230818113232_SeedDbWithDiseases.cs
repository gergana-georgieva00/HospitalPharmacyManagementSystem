using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPharmacyManagementSystem.Data.Migrations
{
    public partial class SeedDbWithDiseases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("16f97942-02eb-4030-9113-5f4ad579c9c7"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("65b007be-103c-4e41-9c4b-0b61274b7a5d"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("9464d9a5-5691-41cc-b286-327c97e6d8a0"));

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "Price" },
                values: new object[] { new Guid("9f2f28b0-a9f2-4488-9905-f8504e058488"), "Advil", 1, "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", 15.92m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "Price" },
                values: new object[] { new Guid("ccded0b1-2dec-43dd-a9c5-0b6f41cc6399"), "Nature Made Fish Oil", 3, "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", 24.99m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "Price" },
                values: new object[] { new Guid("f6bc1e11-c7fa-4e65-ab76-8ce097ea528d"), "Lipitor", 2, "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", 20.71m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("9f2f28b0-a9f2-4488-9905-f8504e058488"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("ccded0b1-2dec-43dd-a9c5-0b6f41cc6399"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("f6bc1e11-c7fa-4e65-ab76-8ce097ea528d"));

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("16f97942-02eb-4030-9113-5f4ad579c9c7"), "Nature Made Fish Oil", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", false, 24.99m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("65b007be-103c-4e41-9c4b-0b61274b7a5d"), "Lipitor", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", false, 20.71m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("9464d9a5-5691-41cc-b286-327c97e6d8a0"), "Advil", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", false, 15.92m });
        }
    }
}

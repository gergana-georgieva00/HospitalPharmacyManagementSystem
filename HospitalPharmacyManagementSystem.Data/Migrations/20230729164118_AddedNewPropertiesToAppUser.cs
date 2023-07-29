using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPharmacyManagementSystem.Data.Migrations
{
    public partial class AddedNewPropertiesToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("2579b281-27b4-4cb0-848e-2d27953d069c"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("26a75e4e-9ce7-420c-8129-eac6d15adb2d"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("f255391f-e1df-4b66-8dae-50ac1400f43f"));

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "PharmacistId", "Price" },
                values: new object[] { new Guid("2ab7157e-1add-40bc-9c32-87a194cb314d"), "Lipitor", 2, "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", new Guid("1b65aad4-f701-4209-84db-746688809c34"), 20.71m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "PharmacistId", "Price" },
                values: new object[] { new Guid("56c779c4-c548-4251-8f48-1493f834c1a6"), "Nature Made Fish Oil", 3, "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", new Guid("1b65aad4-f701-4209-84db-746688809c34"), 24.99m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "PharmacistId", "Price" },
                values: new object[] { new Guid("74c548fc-90b6-4479-8b12-8a14d8a39ccb"), "Advil", 1, "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", new Guid("1b65aad4-f701-4209-84db-746688809c34"), 15.92m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "PharmacistId", "Price" },
                values: new object[] { new Guid("2579b281-27b4-4cb0-848e-2d27953d069c"), "Advil", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", false, new Guid("1b65aad4-f701-4209-84db-746688809c34"), 15.92m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "PharmacistId", "Price" },
                values: new object[] { new Guid("26a75e4e-9ce7-420c-8129-eac6d15adb2d"), "Lipitor", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", false, new Guid("1b65aad4-f701-4209-84db-746688809c34"), 20.71m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "PharmacistId", "Price" },
                values: new object[] { new Guid("f255391f-e1df-4b66-8dae-50ac1400f43f"), "Nature Made Fish Oil", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", false, new Guid("1b65aad4-f701-4209-84db-746688809c34"), 24.99m });
        }
    }
}

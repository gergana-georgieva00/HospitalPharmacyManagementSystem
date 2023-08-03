using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPharmacyManagementSystem.Data.Migrations
{
    public partial class AddFirstNameAndAgeToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Categories_CategoryId",
                table: "Drugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacists_AspNetUsers_UserId",
                table: "Pharmacists");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_AspNetUsers_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Drugs_MedicationId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Pharmacists_PharmacistId",
                table: "Prescriptions");

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("4365ac66-017e-409e-8819-44dd02a8e2ae"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("6cfb2f70-68a7-4ba5-b7eb-6b3b77c2e3d0"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("cc75d015-ff34-4968-8d45-5ece051ab43a"));

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "Price" },
                values: new object[] { new Guid("3f3d5146-40be-42f0-a91f-86feee9bbb7d"), "Nature Made Fish Oil", 3, "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", 24.99m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "Price" },
                values: new object[] { new Guid("48dc8acf-e2d7-4f8c-bc92-fd8b3ad0ac16"), "Lipitor", 2, "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", 20.71m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Form", "ImageUrl", "Price" },
                values: new object[] { new Guid("fc085f59-9475-4383-84aa-44cd6ecb257c"), "Advil", 1, "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", 15.92m });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Categories_CategoryId",
                table: "Drugs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacists_AspNetUsers_UserId",
                table: "Pharmacists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_AspNetUsers_PatientId",
                table: "Prescriptions",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Drugs_MedicationId",
                table: "Prescriptions",
                column: "MedicationId",
                principalTable: "Drugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Pharmacists_PharmacistId",
                table: "Prescriptions",
                column: "PharmacistId",
                principalTable: "Pharmacists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Categories_CategoryId",
                table: "Drugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacists_AspNetUsers_UserId",
                table: "Pharmacists");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_AspNetUsers_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Drugs_MedicationId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Pharmacists_PharmacistId",
                table: "Prescriptions");

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("3f3d5146-40be-42f0-a91f-86feee9bbb7d"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("48dc8acf-e2d7-4f8c-bc92-fd8b3ad0ac16"));

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: new Guid("fc085f59-9475-4383-84aa-44cd6ecb257c"));

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("4365ac66-017e-409e-8819-44dd02a8e2ae"), "Nature Made Fish Oil", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omega-3 fatty acids (EPA and DHA) found in fish and other marine life help support a healthy heart.", 2, "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg", false, 24.99m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("6cfb2f70-68a7-4ba5-b7eb-6b3b77c2e3d0"), "Advil", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provides quick relief for tough pains including headaches, muscle aches, backaches, menstrual pain, minor arthritis and more", 1, "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg", false, 15.92m });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "BrandName", "CategoryId", "CreatedOn", "Description", "Form", "ImageUrl", "IsActive", "Price" },
                values: new object[] { new Guid("cc75d015-ff34-4968-8d45-5ece051ab43a"), "Lipitor", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIPITOR is a prescription medicine that contains a cholesterol lowering medicine (statin) called atorvastatin.", 1, "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp", false, 20.71m });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Categories_CategoryId",
                table: "Drugs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacists_AspNetUsers_UserId",
                table: "Pharmacists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_AspNetUsers_PatientId",
                table: "Prescriptions",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Drugs_MedicationId",
                table: "Prescriptions",
                column: "MedicationId",
                principalTable: "Drugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Pharmacists_PharmacistId",
                table: "Prescriptions",
                column: "PharmacistId",
                principalTable: "Pharmacists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

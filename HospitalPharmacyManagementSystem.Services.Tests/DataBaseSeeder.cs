using HospitalPharmacyManagementSystem.Data;
using HospitalPharmacyManagementSystem.Data.Models;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPharmacyManagementSystem.Services.Tests
{
    public static class DatabaseSeeder
    {
        public static AppUser PharmacistUser;
        public static AppUser PatientUser;
        public static Pharmacist Pharmacist;
        public static Category Category;
        public static Drug Drug;

        public static void SeedDatabase(HospitalPharmacyManagementSystemDbContext dbContext)
        {
            PharmacistUser = new AppUser()
            {
                Id = Guid.Parse("AC08E4B9-C160-4ED6-BC83-9C935BF11951"),
                UserName = "gerganaPharmacist@gmail.com",
                NormalizedUserName = "GERGANAPHARMACIST@GMAIL.COM",
                Email = "gerganaPharmacist@gmail.com",
                NormalizedEmail = "GERGANAPHARMACIST@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEJ/bwr+dzffeqKt/TSwD0vBcU36AwcOd0ejd2ktuw9gIh+L3zrxalGw1UZo7Wr+B5A==",
                ConcurrencyStamp = "443d8adf-c6d7-47f4-9e15-eb9f29fa88f7",
                SecurityStamp = "6Z5MJOVOOQ4AMMM4XYXPECUZCBLGDQ2Y",
                TwoFactorEnabled = false,
                FullName = "Pharmacevt Pharmacevtov"
            };
            PatientUser = new AppUser()
            {
                Id = Guid.Parse("C0BCC73A-D87C-4D81-BDE4-20FFAEE2C93E"),
                UserName = "patient@gmail.com",
                NormalizedUserName = "PATIENT@GMAIL.COM",
                Email = "patient@gmail.com",
                NormalizedEmail = "PATIENT@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEGw8M9z+JF/C+M/7SPYBn7mTah07nBfCsEHs4twALuK9ObdqmkIbZGF29AxCgYQu7w==",
                ConcurrencyStamp = "baf68241-1eb0-448e-b53a-eda16c242ed2",
                SecurityStamp = "JWS7GI53VDBW3RMPUAYPSSEK3BXIJGYH",
                TwoFactorEnabled = false,
                FullName = "Patient Patientov"
            };
            Pharmacist = new Pharmacist()
            {
                Id = Guid.Parse("AF814777-0299-4041-AA12-F800EA5A25DA"),
                HospitalIdNumber = "12345678",
                User = PharmacistUser
            };
            Category = new Category()
            {
                Id = 1,
                Name = "Over-the-counter"
            };
            dbContext.Categories.Add(Category);
            Category = new Category()
            {
                Id = 2,
                Name = "Prescription"
            };
            dbContext.Categories.Add(Category);
            Category = new Category()
            {
                Id = 3,
                Name = "Complementary medicine"
            };
            dbContext.Categories.Add(Category);
            Drug = new Drug()
            {
                Id = Guid.Parse("AEC8649C-11B7-4040-AF70-23AA5F293EB3"),
                BrandName = "Lipitor",
                Form = Common.Enums.DrugForm.Tablet,
                Description = "LIPITOR is a prescription medicine that contains a cholesterol " +
                "lowering medicine (statin) called atorvastatin.",
                ImageUrl = "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp",
                Price = 20.71m,
                CreatedOn = DateTime.Now,
                CategoryId = 2,
                IsActive = true
            };
            var Prescription = new Prescription()
            {
                Id = Guid.Parse("DC8AF683-A9F7-4197-9771-641C055758B8"),
                PharmacistId = Guid.Parse("AF814777-0299-4041-AA12-F800EA5A25DA"),
                PatientId = Guid.Parse("C0BCC73A-D87C-4D81-BDE4-20FFAEE2C93E"),
                CreatedOn = DateTime.Now,
                ValidUntil = DateTime.Now,
                MedicationId = Guid.Parse("AEC8649C-11B7-4040-AF70-23AA5F293EB3"),
                DiseaseId = 1,
                MedicationFrequency = "",
                Notes = ""
            };

            dbContext.Users.Add(PharmacistUser);
            dbContext.Users.Add(PatientUser);
            dbContext.Pharmacists.Add(Pharmacist);
            dbContext.Categories.Add(Category);
            dbContext.Drugs.Add(Drug);
            dbContext.Prescriptions.Add(Prescription);

            dbContext.SaveChanges();
        }
    }
}

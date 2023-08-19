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
        public static Disease Disease;

        public static void SeedDatabase(HospitalPharmacyManagementSystemDbContext dbContext)
        {
            PharmacistUser = new AppUser()
            {
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
                HospitalIdNumber = "12345678",
                User = PharmacistUser
            };
            Category = new Category()
            {
                Id = 1,
                Name = "Over-the-counter"
            };
            Disease = new Disease()
            {
                Id = 1,
                Name = "Heart Disease"
            };

            dbContext.Users.Add(PharmacistUser);
            dbContext.Users.Add(PatientUser);
            dbContext.Pharmacists.Add(Pharmacist);
            dbContext.Categories.Add(Category);
            dbContext.Diseases.Add(Disease);

            dbContext.SaveChanges();
        }
    }
}

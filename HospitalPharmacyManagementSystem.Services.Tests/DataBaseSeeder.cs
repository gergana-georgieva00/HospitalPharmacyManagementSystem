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
    public class DataBaseSeeder
    {
        public static class DatabaseSeeder
        {
            public static AppUser PharmacistUser;
            public static AppUser PatientUser;
            public static Pharmacist Pharmacist;

            public static void SeedDatabase(HospitalPharmacyManagementSystemDbContext dbContext)
            {
                PharmacistUser = new AppUser()
                {
                    UserName = "Pesho",
                    NormalizedUserName = "PESHO",
                    Email = "pesho@agents.com",
                    NormalizedEmail = "PESHO@AGENTS.COM",
                    EmailConfirmed = true,
                    PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                    ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                    SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
                    TwoFactorEnabled = false,
                    FullName = "Pharmacist Ph"
                };
                PatientUser = new AppUser()
                {
                    UserName = "Gosho",
                    NormalizedUserName = "GOSHO",
                    Email = "gosho@renters.com",
                    NormalizedEmail = "GOSHO@RENTERS.COM",
                    EmailConfirmed = true,
                    PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                    ConcurrencyStamp = "8b51706e-f6e8-4dae-b240-54f856fb3004",
                    SecurityStamp = "f6af46f5-74ba-43dc-927b-ad83497d0387",
                    TwoFactorEnabled = false,
                    FullName = "Patient Pa"
                };
                Pharmacist = new Pharmacist()
                {
                    HospitalIdNumber = "09876543",
                    User = PharmacistUser
                };

                dbContext.Users.Add(PharmacistUser);
                dbContext.Users.Add(PatientUser);
                dbContext.Pharmacists.Add(Pharmacist);

                dbContext.SaveChanges();
            }
        }
    }
}

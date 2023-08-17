using HospitalPharmacyManagementSystem.Common.Enums;
using HospitalPharmacyManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalPharmacyManagementSystem.Data.Configurations
{
    public class AppUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .Property(u => u.FullName)
                .HasDefaultValue("Test");

            builder
                .Property(u => u.Age)
                .HasDefaultValue("20");
            builder
                .Property(u => u.Gender)
                .HasDefaultValue(Gender.Male);
        }
    }
}

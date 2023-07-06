namespace HospitalPharmacyManagementSystem.Web.Data
{
    using HospitalPharmacyManagementSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class HospitalPharmacyManagementSystemDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public HospitalPharmacyManagementSystemDbContext(DbContextOptions<HospitalPharmacyManagementSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Drug> Drugs { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Pharmacist> Pharmacists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var configAssembly = Assembly.GetAssembly(typeof(HospitalPharmacyManagementSystemDbContext)) ??
                                 Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}
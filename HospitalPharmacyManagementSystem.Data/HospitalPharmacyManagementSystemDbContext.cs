namespace HospitalPharmacyManagementSystem.Data
{
    using HospitalPharmacyManagementSystem.Data.Configurations;
    using HospitalPharmacyManagementSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class HospitalPharmacyManagementSystemDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;

        public HospitalPharmacyManagementSystemDbContext
            (DbContextOptions<HospitalPharmacyManagementSystemDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Drug> Drugs { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Pharmacist> Pharmacists { get; set; } = null!;
        public DbSet<Prescription> Prescriptions { get; set; } = null!;
        public DbSet<Disease> Diseases { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //var configAssembly = Assembly.GetAssembly(typeof(HospitalPharmacyManagementSystemDbContext)) ??
            //                     Assembly.GetExecutingAssembly();

            //builder.ApplyConfigurationsFromAssembly(configAssembly);

            builder.ApplyConfiguration(new AppUserEntityConfiguration());
            builder.ApplyConfiguration(new DrugEntityConfiguration());
            builder.ApplyConfiguration(new DiseaseEntityConfiguration());

            if (this.seedDb)
            {
                builder.ApplyConfiguration(new CategoryEntityConfiguration());
                builder.ApplyConfiguration(new SeedDrugsEntityConfiguration());
            }

            base.OnModelCreating(builder);
        }
    }
}
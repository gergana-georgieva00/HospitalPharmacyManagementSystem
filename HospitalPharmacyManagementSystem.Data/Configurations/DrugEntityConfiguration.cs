namespace HospitalPharmacyManagementSystem.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DrugEntityConfiguration : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.Property(d => d.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(d => d.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(d => d.Category)
                .WithMany(c => c.Drugs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(d => d.Pharmacist)
                .WithMany(p => p.PrescribedDrugs)
                .HasForeignKey(d => d.PharmacistId) 
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateDrugs());
        }

        private Drug[] GenerateDrugs()
        {
            ICollection<Drug> drugs = new HashSet<Drug>();

            Drug drug;
            drug = new Drug()
            {
                BrandName = "Advil",
                Form = Common.Enums.DrugForm.Tablet,
                Description = "Provides quick relief for tough pains including headaches" +
                ", muscle aches, backaches, menstrual pain, minor arthritis and more",
                ImageUrl = "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg",
                Price = 15.92m,
                CategoryId = 1,
                PharmacistId = Guid.Parse("1B65AAD4-F701-4209-84DB-746688809C34")
            };
            drugs.Add(drug);

            drug = new Drug()
            {
                BrandName = "Lipitor",
                Form = Common.Enums.DrugForm.Tablet,
                Description = "LIPITOR is a prescription medicine that contains a cholesterol " +
                "lowering medicine (statin) called atorvastatin.",
                ImageUrl = "https://pharmacy.ansvel.com.ng/wp-content/uploads/sites/10/2016/03/lipitor-_atorvastatin-calcium_-10mg-x30-tabs-1_fxljg4_500x.webp",
                Price = 20.71m,
                CategoryId = 2,
                PharmacistId = Guid.Parse("1B65AAD4-F701-4209-84DB-746688809C34")
            };
            drugs.Add(drug);

            drug = new Drug()
            {
                BrandName = "Nature Made Fish Oil",
                Form = Common.Enums.DrugForm.Capsule,
                Description = "The Omega-3 fatty acids (EPA and DHA) found in fish " +
                "and other marine life help support a healthy heart.",
                ImageUrl = "https://www.bioshop.bg/images/detailed/10/nature-way-fish-oil.jpg",
                Price = 24.99m,
                CategoryId = 3,
                PharmacistId = Guid.Parse("1B65AAD4-F701-4209-84DB-746688809C34")
            };
            drugs.Add(drug);

            return drugs.ToArray();
        }
    }
}

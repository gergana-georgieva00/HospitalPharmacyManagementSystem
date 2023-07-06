namespace HospitalPharmacyManagementSystem.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DrugEntityConfiguration : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
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
                PharmacistId = Guid.Parse("1B65AAD4-F701-4209-84DB-746688809C34"),
                PatientId = Guid.Parse("BC80B1C0-3BA4-419E-ED9A-08DB7E2D50C1")
            };
            drugs.Add(drug);



            return drugs.ToArray();
        }
    }
}

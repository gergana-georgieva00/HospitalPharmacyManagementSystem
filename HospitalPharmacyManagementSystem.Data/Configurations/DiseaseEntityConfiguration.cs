namespace HospitalPharmacyManagementSystem.Data.Configurations
{
    using HospitalPharmacyManagementSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DiseaseEntityConfiguration : IEntityTypeConfiguration<Disease>
    {
        public void Configure(EntityTypeBuilder<Disease> builder)
        {
            builder.HasData(this.GenerateDiseases());
        }

        private Disease[] GenerateDiseases()
        {
            ICollection<Disease> diseases = new HashSet<Disease>();

            Disease disease;
            disease = new Disease()
            {
                Id = 1,
                Name = "Heart Disease"
            };
            diseases.Add(disease);

            disease = new Disease()
            {
                Id = 2,
                Name = "Skin Cancer"
            };
            diseases.Add(disease);

            disease = new Disease()
            {
                Id = 3,
                Name = "Obesity"
            };
            diseases.Add(disease);

            disease = new Disease()
            {
                Id = 4,
                Name = "Chronic Respiratory Disease"
            };
            diseases.Add(disease);

            disease = new Disease()
            {
                Id = 5,
                Name = "Type two Diabetes"
            };
            diseases.Add(disease);

            disease = new Disease()
            {
                Id = 6,
                Name = "Influenza"
            };
            diseases.Add(disease);

            return diseases.ToArray();
        }
    }
}

namespace HospitalPharmacyManagementSystem.Data.Models
{
    using HospitalPharmacyManagementSystem.Common.Enums;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Drug;

    public class Drug
    {
        public Drug()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(BrandNameMaxLength)]
        public string BrandName { get; set; } = null!;

        [Required]
        public DrugForm Form { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public Guid PharmacistId { get; set; }

        public virtual Pharmacist Pharmacist { get; set; } = null!;

        public Guid? PatientId { get; set; }
        public virtual AppUser? Patient { get; set; }
    }
}

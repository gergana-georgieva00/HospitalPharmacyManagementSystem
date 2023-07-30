namespace HospitalPharmacyManagementSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Prescription;

    public class Prescription
    {
        public Prescription()
        {
            Id = Guid.NewGuid();
            ValidUntil = CreatedOn.AddDays(7);
        }

        [Key]
        public Guid Id { get; set; }
        public Guid PharmacistId { get; set; }
        public virtual Pharmacist Pharmacist { get; set; } = null!;
        public Guid UserId { get; set; }
        public AppUser Patient { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ValidUntil { get; set; }
        public virtual ICollection<Drug> Medications { get; set; } = new HashSet<Drug>();

        [MaxLength(MedicationFrequencyMaxLength)]
        public string MedicationFrequency { get; set; } = null!;

        [MaxLength(NotesMaxLength)]
        public string Notes { get; set; } = null!;
    }
}

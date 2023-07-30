namespace HospitalPharmacyManagementSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Prescription;

    public class Prescription
    {
        public Prescription()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public int PharmacistId { get; set; }
        public virtual Pharmacist Pharmacist { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime ValidUntil { get; set; }
        public virtual ICollection<Drug> Prescriptions { get; set; } = new HashSet<Drug>();

        [MaxLength(MedicationFrequencyMaxLength)]
        public string MedicationFrequency { get; set; } = null!;

        [MaxLength(NotesMaxLength)]
        public string Notes { get; set; } = null!;
    }
}

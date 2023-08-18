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
        public Guid PatientId { get; set; }
        public virtual AppUser Patient { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime ValidUntil { get; set; }
        public virtual Drug Medication { get; set; } = null!;
        public Guid MedicationId { get; set; }
        public int DiseaseId { get; set; }

        public virtual Disease Disease { get; set; } = null!;

        [MaxLength(MedicationFrequencyMaxLength)]
        public string MedicationFrequency { get; set; } = null!;

        [MaxLength(NotesMaxLength)]
        public string Notes { get; set; } = null!;
    }
}

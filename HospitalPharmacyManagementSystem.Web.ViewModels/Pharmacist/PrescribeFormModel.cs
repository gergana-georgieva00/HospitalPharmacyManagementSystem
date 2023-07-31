namespace HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist
{
    using static Common.EntityValidationConstants.Patient;
    using static Common.EntityValidationConstants.Prescription;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
    using System.ComponentModel.DataAnnotations;

    public class PrescribeFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Patient Full Name")]
        public string PatientFullName { get; set; } = null!;
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public IEnumerable<DrugAllViewModel> Drugs { get; set; } = new HashSet<DrugAllViewModel>();

        [Display(Name = "Drugs")]
        public IEnumerable<string> DrugsIds { get; set; } = null!;

        [Required]
        [StringLength(MedicationFrequencyMaxLength, MinimumLength = MedicationFrequencyMinLength)]
        [Display(Name = "Medication Frequency")]
        public string MedicationFrequency { get; set; } = null!;

        [StringLength(NotesMaxLength, MinimumLength = NotesMinLength)]
        public string Notes { get; set; } = null!;
    }
}

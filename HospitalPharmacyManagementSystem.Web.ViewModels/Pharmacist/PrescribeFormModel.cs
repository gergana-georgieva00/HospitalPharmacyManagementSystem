namespace HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist
{
    using static Common.EntityValidationConstants.Patient;
    using static Common.EntityValidationConstants.Prescription;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
    using System.ComponentModel.DataAnnotations;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Disease;

    public class PrescribeFormModel
    {
        [Required]
        [Display(Name = "Patient Email")]
        public string PatientEmail { get; set; } = null!;

        public string Gender { get; set; } = null!;
        public IEnumerable<SelectDrugViewModel> Drugs { get; set; } = new HashSet<SelectDrugViewModel>();

        [Display(Name = "Drugs")]
        public string DrugId { get; set; } = null!;

        public IEnumerable<SelectDiseaseViewModel> Diseases { get; set; } = new HashSet<SelectDiseaseViewModel>();

        [Display(Name = "Diseases")]
        public int DiseaseId { get; set; }

        [Required]
        [StringLength(MedicationFrequencyMaxLength, MinimumLength = MedicationFrequencyMinLength)]
        [Display(Name = "Medication Frequency")]
        public string MedicationFrequency { get; set; } = null!;

        [StringLength(NotesMaxLength, MinimumLength = NotesMinLength)]
        public string Notes { get; set; } = null!;
    }
}

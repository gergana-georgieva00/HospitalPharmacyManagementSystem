using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
using System.ComponentModel.DataAnnotations;

namespace HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist
{
    public class PrescriptionViewModel
    {
        public string Id { get; set; } = null!;
        public string PharmacistId { get; set; } = null!;
        public string PatientEmail { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime ValidUntil { get; set; }
        public string DrugBrandName { get; set; } = null!;
        public string DiseaseName { get; set; } = null!;
        public string MedicationFrequency { get; set; } = null!;
        public string Notes { get; set; } = null!;
    }
}

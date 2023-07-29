using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
using System.ComponentModel.DataAnnotations;

namespace HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist
{
    public class PrescribeFormModel
    {
        public PrescribeFormModel()
        {
            Drugs = new HashSet<DrugAllViewModel>();
        }

        public string PatientFullName { get; set; } = null!;
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public IEnumerable<DrugAllViewModel> Drugs { get; set; }
        public string MedicationFrequency { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public int PrescriptionCode { get; set; }
    }
}

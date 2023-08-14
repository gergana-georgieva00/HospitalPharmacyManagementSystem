using HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist;

namespace HospitalPharmacyManagementSystem.Web.Areas.Admin.ViewModels.Drug
{
    public class MyDrugsViewModel
    {
        public IEnumerable<PrescriptionViewModel> PrescribedDrugs { get; set; } = null!;
    }
}

using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;

namespace HospitalPharmacyManagementSystem.Services.Data.Models.Drug
{
    public class AllDrugsFilteredAndPagedServiceModel
    {
        public int TotalDrugsCount { get; set; }
        public IEnumerable<DrugAllViewModel> Drugs { get; set; } = new HashSet<DrugAllViewModel>();
    }
}

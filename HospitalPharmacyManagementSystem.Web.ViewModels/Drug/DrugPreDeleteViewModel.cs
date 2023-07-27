using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HospitalPharmacyManagementSystem.Web.ViewModels.Drug
{
    public class DrugPreDeleteViewModel
    {
        public string BrandName { get; set; } = null!;
        public string Details { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
    }
}

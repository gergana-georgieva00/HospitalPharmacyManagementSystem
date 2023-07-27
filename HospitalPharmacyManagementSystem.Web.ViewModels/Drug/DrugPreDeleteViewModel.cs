using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HospitalPharmacyManagementSystem.Web.ViewModels.Drug
{
    public class DrugPreDeleteViewModel
    {
        [Display(Name = "Brand Name")]

        public string BrandName { get; set; } = null!;
        public string Description { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
    }
}

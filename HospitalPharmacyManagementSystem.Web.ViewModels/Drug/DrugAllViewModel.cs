using System.ComponentModel.DataAnnotations;

namespace HospitalPharmacyManagementSystem.Web.ViewModels.Drug
{
    public class DrugAllViewModel
    {
        public string Id { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string Description { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
    }
}

using HospitalPharmacyManagementSystem.Web.ViewModels.Category;
using System.ComponentModel.DataAnnotations;

namespace HospitalPharmacyManagementSystem.Web.ViewModels.Drug
{
    using static Common.EntityValidationConstants.Drug;

    public class AddDrugViewModel
    {
        [Required]
        [StringLength(BrandNameMaxLength, MinimumLength = BrandNameMinLength)]
        public string BrandName { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display (Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Display(Name = "Drug Price")]
        public decimal PricePerPackage { get; set; }


        public IEnumerable<DrugSelectCategoryViewModel> Categories { get; set; } = new HashSet<DrugSelectCategoryViewModel>();

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}

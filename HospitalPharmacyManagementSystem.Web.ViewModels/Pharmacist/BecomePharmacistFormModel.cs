
namespace HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Pharmacist;

    public class BecomePharmacistFormModel
    {
        [Required]
        [StringLength(HospitalIdNumberLength, ErrorMessage = 
            "Incorrect HospitalId length! Must be exactly 8 characters!")]
        [Display(Name = "Hospital ID")]
        public string HospitalIdNumber { get; set; } = null!;
    }
}

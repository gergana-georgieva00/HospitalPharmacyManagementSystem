namespace HospitalPharmacyManagementSystem.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.AppUser;

    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Full name")]
        public string FullName { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HospitalPharmacyManagementSystem.Web.ViewModels.User
{
    public class LoginFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

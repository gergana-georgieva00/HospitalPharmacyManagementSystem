namespace HospitalPharmacyManagementSystem.Data.Models
{
    using HospitalPharmacyManagementSystem.Common.Enums;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.AppUser;

    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
    }
}

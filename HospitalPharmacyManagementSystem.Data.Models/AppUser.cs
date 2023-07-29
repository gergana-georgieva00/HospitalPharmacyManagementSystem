namespace HospitalPharmacyManagementSystem.Data.Models
{
    using HospitalPharmacyManagementSystem.Common.Enums;
    using Microsoft.AspNetCore.Identity;

    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            Id = Guid.NewGuid();
        }

        public string FullName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public virtual ICollection<Drug> Prescriptions { get; set; } = new HashSet<Drug>();
    }
}

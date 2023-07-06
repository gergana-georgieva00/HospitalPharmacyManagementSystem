namespace HospitalPharmacyManagementSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            Id = Guid.NewGuid();
        }

        public virtual ICollection<Drug> Prescriptions { get; set; } = new HashSet<Drug>();
    }
}

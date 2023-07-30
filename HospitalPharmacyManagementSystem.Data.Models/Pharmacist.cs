namespace HospitalPharmacyManagementSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Pharmacist;

    public class Pharmacist
    {
        public Pharmacist()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(HospitalIdNumberLength)]
        public string HospitalIdNumber { get; set; } = null!;

        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; } = null!;

        public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPharmacyManagementSystem.Data.Models
{
    public class Prescription
    {
        public Prescription()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public int PharmacistId { get; set; }
        public virtual Pharmacist Pharmacist { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ValidUntil { get; set; }
        public virtual ICollection<Drug> Prescriptions { get; set; } = new HashSet<Drug>();
        public string MedicationFrequency { get; set; }
        public string Notes { get; set; }
    }
}

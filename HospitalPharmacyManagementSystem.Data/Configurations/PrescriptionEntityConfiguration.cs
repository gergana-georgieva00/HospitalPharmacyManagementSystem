using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalPharmacyManagementSystem.Data.Models;

namespace HospitalPharmacyManagementSystem.Data.Configurations
{
    public class PrescriptionEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETDATE()");


            builder
                .HasOne(p => p.Pharmacist)
                .WithMany(ph => ph.Prescriptions)
                .HasForeignKey(p => p.PharmacistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Patient)
                .WithMany(pa => pa.Prescriptions)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

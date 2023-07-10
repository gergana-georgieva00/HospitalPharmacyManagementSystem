namespace HospitalPharmacyManagementSystem.Services.Data
{
    using HospitalPharmacyManagementSystem.Data.Models;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Web.Data;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist;
    using Microsoft.EntityFrameworkCore;


    public class PharmacistService : IPharmacistService
    {
        private readonly HospitalPharmacyManagementSystemDbContext dbContext;

        public PharmacistService(HospitalPharmacyManagementSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(string userId, BecomePharmacistFormModel model)
        {
            Pharmacist pharmacist = new Pharmacist()
            {
                Id = Guid.Parse(userId),
                HospitalIdNumber = model.HospitalIdNumber
            };

            await this.dbContext.AddAsync(pharmacist);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> PharmacistExistsByHospitalIdAsync(string hospitalId)
        {
            bool result = await this.dbContext.Pharmacists
                .AnyAsync(p => p.HospitalIdNumber.ToString() == hospitalId);

            return result;
        }

        public async Task<bool> PharmacistExistsByUserIdAsync(string userId)
        {
            bool result = await this.dbContext.Pharmacists
                .AnyAsync(p => p.UserId.ToString() == userId);

            return result;
        }
    }
}

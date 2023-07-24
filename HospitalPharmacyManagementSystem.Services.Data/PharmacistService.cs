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
                UserId = Guid.Parse(userId),
                HospitalIdNumber = model.HospitalIdNumber
            };

            await this.dbContext.Pharmacists.AddAsync(pharmacist);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<string?> GetPharmacistIdByUserIdAsync(string userId)
        {
            Pharmacist? pharmacist = await this.dbContext
                .Pharmacists
                .FirstOrDefaultAsync(p => p.UserId.ToString() == userId);

            if (pharmacist is null)
            {
                return null;
            }

            return pharmacist.Id.ToString();
        }

        public async Task<bool> PharmacistExistsByHospitalIdAsync(string hospitalId)
        {
            bool result = await this.dbContext.Pharmacists
                .AnyAsync(p => p.HospitalIdNumber == hospitalId);

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

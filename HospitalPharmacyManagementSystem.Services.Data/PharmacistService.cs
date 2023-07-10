using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
using HospitalPharmacyManagementSystem.Web.Data;
using HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist;
using Microsoft.EntityFrameworkCore;

namespace HospitalPharmacyManagementSystem.Services.Data
{
    public class PharmacistService : IPharmacistService
    {
        private readonly HospitalPharmacyManagementSystemDbContext dbContext;

        public PharmacistService(HospitalPharmacyManagementSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Create(string userId, BecomePharmacistFormModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PharmacistExistsByHospitalIdAsync(string hospitalId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PharmacistExistsByUserIdAsync(string userId)
        {
            bool result = await this.dbContext.Pharmacists
                .AnyAsync(p => p.UserId.ToString() == userId);

            return result;
        }
    }
}

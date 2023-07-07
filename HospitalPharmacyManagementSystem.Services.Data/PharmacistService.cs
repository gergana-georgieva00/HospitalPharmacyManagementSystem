using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
using HospitalPharmacyManagementSystem.Web.Data;
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

        public async Task<bool> PharmacistExistsByUserId(string userId)
        {
            bool result = await this.dbContext.Pharmacists
                .AnyAsync(p => p.UserId.ToString() == userId);

            return result;
        }
    }
}

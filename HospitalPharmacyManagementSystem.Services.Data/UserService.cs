namespace HospitalPharmacyManagementSystem.Services.Data
{
    using HospitalPharmacyManagementSystem.Data.Models;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Web.Data;
    using HospitalPharmacyManagementSystem.Web.ViewModels.User;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly HospitalPharmacyManagementSystemDbContext dbContext;

        public UserService(HospitalPharmacyManagementSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IEnumerable<UserViewModel>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            AppUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FullName}";
        }

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            var user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user is null)
            {
                return "";
            }

            return user.FullName;
        }
    }
}

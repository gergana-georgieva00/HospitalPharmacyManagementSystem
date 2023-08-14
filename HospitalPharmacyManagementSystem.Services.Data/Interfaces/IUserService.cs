using HospitalPharmacyManagementSystem.Web.ViewModels.User;

namespace HospitalPharmacyManagementSystem.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetFullNameByEmailAsync(string email);
        Task<string> GetFullNameByIdAsync(string userId);
        Task<IEnumerable<UserViewModel>> AllAsync();
    }
}

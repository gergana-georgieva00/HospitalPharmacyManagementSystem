namespace HospitalPharmacyManagementSystem.Services.Data.Interfaces
{
    public interface IPharmacistService
    {
        Task<bool> PharmacistExistsByUserIdAsync(string userId);
    }
}

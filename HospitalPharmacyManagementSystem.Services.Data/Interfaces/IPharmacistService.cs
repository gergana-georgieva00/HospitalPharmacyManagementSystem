namespace HospitalPharmacyManagementSystem.Services.Data.Interfaces
{
    public interface IPharmacistService
    {
        Task<bool> PharmacistExistsByUserId(string userId);
    }
}

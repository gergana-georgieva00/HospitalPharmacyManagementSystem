using HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist;

namespace HospitalPharmacyManagementSystem.Services.Data.Interfaces
{
    public interface IPharmacistService
    {
        Task<bool> PharmacistExistsByUserIdAsync(string userId);
        Task<bool> PharmacistExistsByHospitalIdAsync(string hospitalId);
        Task Create(string userId, BecomePharmacistFormModel model);
        Task<string?> GetPharmacistIdByUserIdAsync(string userId);
        Task PrescribeDrugAsync(/*string drugId, string userId, */PrescribeFormModel formModel);
    }
}

namespace HospitalPharmacyManagementSystem.Services.Data.Interfaces
{
    using HospitalPharmacyManagementSystem.Services.Data.Models.Drug;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Home;

    public interface IDrugService
    {
        Task<IEnumerable<IndexViewModel>> BestDealsAsync();
        Task CreateAsync(AddDrugViewModel formModel, string pharmacistId);
        Task<AllDrugsFilteredAndPagedServiceModel> AllAsync(AllDrugsQueryModel queryModel);
        Task<IEnumerable<DrugAllViewModel>> AllByUserIdAsync(string userId);
        Task<DrugDetailsViewModel> GetDetailsByIdAsync(string drugId);
    }
}

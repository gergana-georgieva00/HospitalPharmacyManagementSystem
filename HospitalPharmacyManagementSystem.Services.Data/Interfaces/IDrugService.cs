namespace HospitalPharmacyManagementSystem.Services.Data.Interfaces
{
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Home;

    public interface IDrugService
    {
        Task<IEnumerable<IndexViewModel>> BestDealsAsync();
        Task CreateAsync(AddDrugViewModel formModel, string pharmacistId);
    }
}

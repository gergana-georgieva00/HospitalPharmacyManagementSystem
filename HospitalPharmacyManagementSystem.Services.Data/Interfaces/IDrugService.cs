﻿namespace HospitalPharmacyManagementSystem.Services.Data.Interfaces
{
    using HospitalPharmacyManagementSystem.Services.Data.Models.Drug;
    using HospitalPharmacyManagementSystem.Services.Data.Models.Statistics;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Home;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist;
    using System.Globalization;

    public interface IDrugService
    {
        Task<IEnumerable<IndexViewModel>> BestDealsAsync();
        Task CreateAsync(AddDrugViewModel formModel, string pharmacistId);
        Task<AllDrugsFilteredAndPagedServiceModel> AllAsync(AllDrugsQueryModel queryModel);
        Task<IEnumerable<SelectDrugViewModel>> AllDrugsAsync();
        Task<IEnumerable<PrescriptionViewModel>> AllByUserIdAsync(string userId);
        Task<PrescriptionViewModel> GetPrescriptionByIdAsync(string id);
        Task<bool> ExistsByIdAsync(string drugId);
        Task<DrugDetailsViewModel> GetDetailsByIdAsync(string drugId);
        Task<AddDrugViewModel> GetDrugForEditByIdAsync(string drugId);
        Task EditDrugByIdAndFormModelAsync(string drugId, AddDrugViewModel formModel);
        Task<DrugPreDeleteViewModel> GetDrugForDeleteByIdAsync(string drugId);
        Task DeleteDrugByIdAsync(string drugId);
        Task<StatisticsServiceModel> GetStatisticsAsync();
    }
}

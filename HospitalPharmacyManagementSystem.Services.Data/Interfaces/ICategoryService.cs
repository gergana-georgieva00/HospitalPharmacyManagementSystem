namespace HospitalPharmacyManagementSystem.Services.Data.Interfaces
{
    using Web.ViewModels.Category

    public interface ICategoryService
    {
        Task<IEnumerable<DrugSelectCategoryViewModel>> AllCategoriesAsync();
    }
}

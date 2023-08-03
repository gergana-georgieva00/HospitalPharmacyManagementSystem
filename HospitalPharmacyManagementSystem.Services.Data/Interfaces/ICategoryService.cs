namespace HospitalPharmacyManagementSystem.Services.Data.Interfaces
{
    using Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<DrugSelectCategoryViewModel>> AllCategoriesAsync();
        Task<IEnumerable<AllCategoriesViewModel>> AllCategoriesForListAsync();
        Task<bool> ExistsByIdAsync(int id);
        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}

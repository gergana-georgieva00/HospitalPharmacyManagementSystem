namespace HospitalPharmacyManagementSystem.Services.Data
{
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Web.Data;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Category;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly HospitalPharmacyManagementSystemDbContext dbContext;

        public CategoryService(HospitalPharmacyManagementSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<DrugSelectCategoryViewModel>> AllCategoriesAsync()
        {
            IEnumerable<DrugSelectCategoryViewModel> allCategories = 
                await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(d => new DrugSelectCategoryViewModel() 
                { 
                    Id = d.Id,
                    Name = d.Name
                })
                .ToArrayAsync();

            return allCategories;
        }
    }
}

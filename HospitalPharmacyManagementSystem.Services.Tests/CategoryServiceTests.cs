﻿namespace HospitalPharmacyManagementSystem.Services.Tests
{
    using HospitalPharmacyManagementSystem.Data;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Services.Data;
    using Microsoft.EntityFrameworkCore;
    using static DatabaseSeeder;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Category;

    public class CategoryServiceTests
    {
        private HospitalPharmacyManagementSystemDbContext dbContext;
        private DbContextOptions<HospitalPharmacyManagementSystemDbContext> dbOptions;
        private ICategoryService categoryService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<HospitalPharmacyManagementSystemDbContext>()
                .UseInMemoryDatabase("HospitalPharmacyInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new HospitalPharmacyManagementSystemDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.categoryService = new CategoryService(this.dbContext);
        }

        //public async Task<IEnumerable<DrugSelectCategoryViewModel>> AllCategoriesAsync()
        //{
        //    IEnumerable<DrugSelectCategoryViewModel> allCategories =
        //        await this.dbContext
        //        .Categories
        //        .AsNoTracking()
        //        .Select(d => new DrugSelectCategoryViewModel()
        //        {
        //            Id = d.Id,
        //            Name = d.Name
        //        })
        //        .ToArrayAsync();

        //    return allCategories;
        //}

        [Test]
        public async Task AllCategoriesAsyncShouldWorkCorrectly()
        {
            var result = await this.categoryService.AllCategoriesAsync();

            Assert.That(result.ToList()[0].Name, Is.EqualTo("Over-the-counter"));
        }
    }
}

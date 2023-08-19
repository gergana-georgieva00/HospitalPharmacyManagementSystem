namespace HospitalPharmacyManagementSystem.Services.Tests
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

        [Test]
        public async Task AllCategoriesAsyncShouldWorkCorrectly()
        {
            var result = await this.categoryService.AllCategoriesAsync();

            Assert.That(result.ToList()[0].Name, Is.EqualTo("Over-the-counter"));
        }

        [Test]
        public async Task AllCategoriesForListAsyncShouldWorkCorrectly()
        {
            var result = await this.categoryService.AllCategoriesForListAsync();

            Assert.That(result.ToList()[0].Name, Is.EqualTo("Over-the-counter"));
        }

        [Test]
        public async Task AllCategoryNamesAsyncShouldWorkCorrectly()
        {
            var result = await this.categoryService.AllCategoryNamesAsync();

            Assert.That(result.ToList()[0], Is.EqualTo("Over-the-counter"));
        }

        [Test]
        public async Task ExistsByIdAsyncShouldWorkCorrectly()
        {
            var result = await this.categoryService.ExistsByIdAsync(1);

            Assert.True(result);
        }

        [Test]
        public async Task GetDetailsByIdAsyncShouldWorkCorrectly()
        {
            var result = await this.categoryService.GetDetailsByIdAsync(1);

            Assert.That(result.Name, Is.EqualTo("Over-the-counter"));
        }
    }
}

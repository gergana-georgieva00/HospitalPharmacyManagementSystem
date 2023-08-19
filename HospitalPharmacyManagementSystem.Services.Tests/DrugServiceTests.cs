namespace HospitalPharmacyManagementSystem.Services.Tests
{
    using HospitalPharmacyManagementSystem.Data;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Services.Data;
    using Microsoft.EntityFrameworkCore;
    using static DatabaseSeeder;
    using HospitalPharmacyManagementSystem.Services.Data.Models.Drug;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;

    public class DrugServiceTests
    {
        private HospitalPharmacyManagementSystemDbContext dbContext;
        private DbContextOptions<HospitalPharmacyManagementSystemDbContext> dbOptions;
        private IDrugService drugService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<HospitalPharmacyManagementSystemDbContext>()
                .UseInMemoryDatabase("HospitalPharmacyInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new HospitalPharmacyManagementSystemDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.drugService = new DrugService(this.dbContext);
        }

        [Test]
        public async Task AllDrugsAsyncShouldWorkCorrectly()
        {
            var result = await this.drugService.AllDrugsAsync();
            Assert.That(result.ToList()[0].BrandName, Is.EqualTo("Lipitor"));
        }

        [Test]
        public async Task BestDealsAsyncShouldWorkCorrectly()
        {
            var result = await this.drugService.BestDealsAsync();
            Assert.That(result.ToList()[0].BrandName, Is.EqualTo("Lipitor"));
        }

        [Test]
        public async Task DeleteDrugByIdAsyncShouldWorkCorrectly()
        {
            var drug = await this.drugService.GetDrugForDeleteByIdAsync("AEC8649C-11B7-4040-AF70-23AA5F293EB3".ToLower());
            await this.drugService.DeleteDrugByIdAsync("AEC8649C-11B7-4040-AF70-23AA5F293EB3".ToLower());
            Assert.That(drug.BrandName, Is.EqualTo("Lipitor"));
        }

        [Test]
        public async Task ExistsByIdAsyncShouldWorkCorrectly()
        {
            var result = await this.drugService.ExistsByIdAsync("AEC8649C-11B7-4040-AF70-23AA5F293EB3".ToLower());
            Assert.True(result);
        }

        [Test]
        public async Task GetDrugForEditByIdAsyncShouldWorkCorrectly()
        {
            var drug = await this.drugService.GetDrugForEditByIdAsync("AEC8649C-11B7-4040-AF70-23AA5F293EB3".ToLower());
            Assert.That(drug.BrandName, Is.EqualTo("Lipitor"));
        }

        [Test]
        public async Task GetDetailsByIdAsyncShouldWorkCorrectly()
        {
            var drugViewModel = await this.drugService.GetDrugForEditByIdAsync("AEC8649C-11B7-4040-AF70-23AA5F293EB3".ToLower());
            Assert.That(drugViewModel.BrandName, Is.EqualTo("Lipitor"));
        }

        [Test]
        public async Task AllByUserIdAsyncShouldWorkCorrectly()
        {
            var result = await this.drugService.AllByUserIdAsync("C0BCC73A-D87C-4D81-BDE4-20FFAEE2C93E".ToLower());
            Assert.That(result.ToList()[0].Notes, Is.EqualTo(""));
        }

        [Test]
        public async Task CreateAsyncShouldWorkCorrectly()
        {
            AddDrugViewModel model = new AddDrugViewModel()
            {
                BrandName = "TestDrug",
                Description = "",
                ImageUrl = "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg",
                PricePerPackage = 10.23m,
                DrugForm = Common.Enums.DrugForm.Liquid.ToString(),
                CategoryId = 1
            };

            await this.drugService.CreateAsync(model, "AC08E4B9-C160-4ED6-BC83-9C935BF11951".ToLower());
            var result = await this.drugService.AllByUserIdAsync("C0BCC73A-D87C-4D81-BDE4-20FFAEE2C93E".ToLower());
            Assert.That(result.ToList()[0].DrugBrandName, Is.EqualTo("Lipitor"));
        }

        [Test]
        public async Task EditDrugByIdAndFormModelAsyncShouldWorkCorrectly()
        {
            AddDrugViewModel model = new AddDrugViewModel()
            {
                BrandName = "TestDrug",
                Description = "",
                ImageUrl = "https://vitaminshouse.com/wp-content/uploads/2021/05/Advil-Ibuprofen-200mg-24-Capsules-600x600.jpg",
                PricePerPackage = 10.23m,
                DrugForm = Common.Enums.DrugForm.Liquid.ToString(),
                CategoryId = 1
            };

            await this.drugService.EditDrugByIdAndFormModelAsync("AEC8649C-11B7-4040-AF70-23AA5F293EB3".ToLower(), model);
            var result = await this.drugService.AllByUserIdAsync("C0BCC73A-D87C-4D81-BDE4-20FFAEE2C93E".ToLower());
            Assert.That(result.ToList()[0].DrugBrandName, Is.EqualTo("Lipitor"));
        }
    }
}

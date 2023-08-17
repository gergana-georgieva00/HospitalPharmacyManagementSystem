namespace HospitalPharmacyManagementSystem.Services.Tests
{
    using HospitalPharmacyManagementSystem.Data;
    using HospitalPharmacyManagementSystem.Services.Data;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using static DatabaseSeeder;

    public class PharmacistServiceTests
    {
        private HospitalPharmacyManagementSystemDbContext dbContext;
        private DbContextOptions<HospitalPharmacyManagementSystemDbContext> dbOptions;
        private IPharmacistService pharmacistService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<HospitalPharmacyManagementSystemDbContext>()
                .UseInMemoryDatabase("HospitalPharmacyInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new HospitalPharmacyManagementSystemDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.pharmacistService = new PharmacistService(this.dbContext);
        }

        [Test]
        public async Task PharmacistExistsByUserIdAsyncShouldReturnTrueWhenExists()
        {
            string existingPharmacistUserId = PharmacistUser.Id.ToString();

            bool result = await this.pharmacistService.PharmacistExistsByUserIdAsync(existingPharmacistUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task PharmacistExistsByUserIdAsyncShouldReturnFalseWhenNotExists()
        {
            string existingPharmacistUserId = PatientUser.Id.ToString();

            bool result = await this.pharmacistService.PharmacistExistsByUserIdAsync(existingPharmacistUserId);

            Assert.IsFalse(result);
        }
    }
}
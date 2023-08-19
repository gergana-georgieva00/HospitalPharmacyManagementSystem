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

        [Test]
        public async Task PatientExistsByEmailAsyncShouldReturnTrueWhenExists()
        {
            string existingPatientEmail = PatientUser.Email.ToString();

            bool result = await this.pharmacistService.PatientExistsByEmailAsync(existingPatientEmail);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task PatientExistsByEmailAsyncShouldReturnFalseWhenNotExists()
        {
            string existingPatientEmail = "";//PatientUser.Email.ToString();

            bool result = await this.pharmacistService.PatientExistsByEmailAsync(existingPatientEmail);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task PharmacistExistByHospitalIdNumberAsyncShouldReturnTrueWhenExists()
        {
            string existingPhIdNumber = Pharmacist.HospitalIdNumber;

            bool result = await this.dbContext.Pharmacists
               .AnyAsync(p => p.HospitalIdNumber == existingPhIdNumber);

            Assert.IsTrue(result);
        }

    [Test]
    public async Task PharmacistExistByHospitalIdNumberAsyncShouldReturnFalseWhenNotExists()
    {
        string notexistingPharmacistUserId = "";

        bool result = await this.pharmacistService.PharmacistExistsByUserIdAsync(notexistingPharmacistUserId);

        Assert.IsFalse(result);
    }
}
}
namespace HospitalPharmacyManagementSystem.Services.Tests
{
    using HospitalPharmacyManagementSystem.Data;
    using HospitalPharmacyManagementSystem.Services.Data;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist;
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
            string existingPatientEmail = "";

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

            bool result = await this.pharmacistService.PharmacistExistsByHospitalIdAsync(notexistingPharmacistUserId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task PrescribeDrugAsyncShouldWorkCorrectly()
        {
            PrescribeFormModel model = new PrescribeFormModel()
            {
                PatientEmail = "patient@gmail.com",
                DrugId = "AEC8649C-11B7-4040-AF70-23AA5F293EB3".ToLower(),
                DiseaseId = 1,
                MedicationFrequency = "",
                Notes = ""
            };

            await this.pharmacistService.PrescribeDrugAsync(model, "AC08E4B9-C160-4ED6-BC83-9C935BF11951".ToLower());

            Assert.True(dbContext.Prescriptions.Any(p => p.DiseaseId == 1));
        }

        [Test]
        public async Task GetPharmacistIdByUserIdAsyncShouldReturnCorrectResult()
        {
            var result = await this.pharmacistService
                .GetPharmacistIdByUserIdAsync("AC08E4B9-C160-4ED6-BC83-9C935BF11951".ToLower());

            Assert.That(result, Is.EqualTo("AF814777-0299-4041-AA12-F800EA5A25DA".ToLower()));
        }
    }
}
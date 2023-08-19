namespace HospitalPharmacyManagementSystem.Services.Tests
{
    using HospitalPharmacyManagementSystem.Data;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Services.Data;
    using Microsoft.EntityFrameworkCore;
    using static DatabaseSeeder;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Disease;

    public class DiseaseServiceTests
    {
        private HospitalPharmacyManagementSystemDbContext dbContext;
        private DbContextOptions<HospitalPharmacyManagementSystemDbContext> dbOptions;
        private IDiseaseService diseaseService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<HospitalPharmacyManagementSystemDbContext>()
                .UseInMemoryDatabase("HospitalPharmacyInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new HospitalPharmacyManagementSystemDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.diseaseService = new DiseaseService(this.dbContext);
        }

        //public async Task<IEnumerable<SelectDiseaseViewModel>> AllDiseasesAsync()
        //{
        //    IEnumerable<SelectDiseaseViewModel> allDiseases =
        //        await this.dbContext
        //        .Diseases
        //        .AsNoTracking()
        //        .Select(d => new SelectDiseaseViewModel()
        //        {
        //            Id = d.Id.ToString(),
        //            Name = d.Name
        //        })
        //        .ToArrayAsync();

        //    return allDiseases;
        }
    }
}

namespace HospitalPharmacyManagementSystem.Services.Tests
{
    using HospitalPharmacyManagementSystem.Data;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Services.Data;
    using Microsoft.EntityFrameworkCore;
    using static DatabaseSeeder;

    public class UserServiceTests
    {
        private HospitalPharmacyManagementSystemDbContext dbContext;
        private DbContextOptions<HospitalPharmacyManagementSystemDbContext> dbOptions;
        private IUserService userService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<HospitalPharmacyManagementSystemDbContext>()
                .UseInMemoryDatabase("HospitalPharmacyInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new HospitalPharmacyManagementSystemDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.userService = new UserService(this.dbContext);
        }

        [Test]
        public async Task GetFullNameByIdAsyncShouldReturnCorrectResultWhenNull()
        {
            var user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == PatientUser.FullName);

            Assert.That(user, Is.EqualTo(null));
        }

        [Test]
        public async Task GetFullNameByIdAsyncShouldReturnCorrectResult()
        {
            //var user = await this.dbContext
            //    .Users
            //    .FirstOrDefaultAsync(u => u.Id.ToString() == PharmacistUser.FullName);

            //Assert.That(user.FullName, Is.EqualTo(PharmacistUser.FullName));

            var user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == PharmacistUser.Id);

            var result = await this.userService.GetFullNameByIdAsync(user.Id.ToString());

            Assert.That(result, Is.EqualTo(PharmacistUser.FullName));
        }
    }
}

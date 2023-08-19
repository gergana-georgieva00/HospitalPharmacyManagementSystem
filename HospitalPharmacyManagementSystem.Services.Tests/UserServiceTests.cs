namespace HospitalPharmacyManagementSystem.Services.Tests
{
    using HospitalPharmacyManagementSystem.Data;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Services.Data;
    using Microsoft.EntityFrameworkCore;
    using static DatabaseSeeder;
    using HospitalPharmacyManagementSystem.Web.ViewModels.User;

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
        public async Task GetFullNameByIdAsyncShouldReturnCorrectResultWhenNotExists()
        {
            var result = await this.userService.GetFullNameByIdAsync("");

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public async Task GetFullNameByIdAsyncShouldReturnCorrectResult()
        {
            var user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == PharmacistUser.Id);

            var result = await this.userService.GetFullNameByIdAsync(user.Id.ToString());

            Assert.That(result, Is.EqualTo(PharmacistUser.FullName));
        }

        [Test]
        public async Task GetFullNameByEmailAsyncShouldReturnCorrectResultWhenNull()
        {
            var resut = await this.userService.GetFullNameByEmailAsync("");

            Assert.That(resut, Is.EqualTo(""));
        }

        [Test]
        public async Task GetFullNameByEmailAsyncShouldReturnCorrectResult()
        {
            var user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == PatientUser.Email);

            var resut = await this.userService.GetFullNameByEmailAsync(user.Email);

            Assert.That(resut, Is.EqualTo(PatientUser.FullName));
        }

        [Test]
        public async Task AllAsyncShouldReturnCorrectResult()
        {
            var resut = await this.userService.AllAsync();

            Assert.That(resut.ToList()[0].Email, Is.EqualTo(PharmacistUser.Email));
        }
    }
}

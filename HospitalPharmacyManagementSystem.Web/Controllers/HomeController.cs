namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Home;
    using HospitalPharmacyManagementSytem.Web.Infrastucture.Extentions;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IDrugService drugService;
        private readonly IPharmacistService pharmacistService;
        public HomeController(IDrugService drugService, IPharmacistService pharmacistService)
        {
            this.drugService = drugService;
            this.pharmacistService = pharmacistService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> model = await this.drugService.BestDealsAsync();
            string userId = this.User.GetId()!;
            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(userId);
            ViewBag.IsUserPharmacist = isUserPharmacist;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
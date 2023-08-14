namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Home;
    using HospitalPharmacyManagementSytem.Web.Infrastucture.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static Common.GeneralAppConstants;

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
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

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
        public IActionResult Error(int statusCode)
        {

            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }

        private async Task<bool> IsUserPharmacist()
        {
            string userId = this.User.GetId()!;
            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(userId);
            return ViewBag.IsUserPharmacist = isUserPharmacist;
        }
    }
}
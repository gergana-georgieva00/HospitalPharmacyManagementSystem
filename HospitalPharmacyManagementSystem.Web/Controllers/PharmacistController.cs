namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    using HospitalPharmacyManagementSystem.Services.Data;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSytem.Web.Infrastucture.Extentions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationMessages;


    [Authorize]
    public class PharmacistController : Controller
    {
        private readonly IPharmacistService pharmacistService;

        public PharmacistController(IPharmacistService pharmacistService)
        {
            this.pharmacistService = pharmacistService;
        }

        [HttpGet]
        public async Task<IActionResult> BecomePharmacist()
        {
            string? userId = this.User.GetId();
            bool isPharmacist = await this.pharmacistService.PharmacistExistsByUserIdAsync(userId);

            if (isPharmacist)
            {
                this.TempData[ErrorMessage] = "You are already a partner!";
                return this.RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}

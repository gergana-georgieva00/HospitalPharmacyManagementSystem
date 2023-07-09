namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    using HospitalPharmacyManagementSystem.Services.Data;
    using HospitalPharmacyManagementSytem.Web.Infrastucture.Extentions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    [Authorize]
    public class PharmacistController : Controller
    {
        private readonly PharmacistService pharmacistService;

        public PharmacistController(PharmacistService pharmacistService)
        {
            this.pharmacistService = pharmacistService;
        }

        [HttpGet]
        public async Task<IActionResult> BecomePharmacist()
        {
            string? userId = this.User.GetId();
            bool isPharmacist = await this.pharmacistService.PharmacistExistsByUserId(userId);

            if (isPharmacist)
            {
                return this.BadRequest();
            }

            return View();
        }
    }
}

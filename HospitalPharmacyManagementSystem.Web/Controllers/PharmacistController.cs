namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    using HospitalPharmacyManagementSystem.Services.Data;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist;
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

        [HttpPost]
        public async Task<IActionResult> BecomePharmacist(BecomePharmacistFormModel model)
        {
            string? userId = this.User.GetId();
            bool isPharmacist = await this.pharmacistService.PharmacistExistsByUserIdAsync(userId);

            if (isPharmacist)
            {
                this.TempData[ErrorMessage] = "You are already a partner!";
                return this.RedirectToAction("Index", "Home");
            }

            bool isIdTaken = await 
                this.pharmacistService.PharmacistExistsByHospitalIdAsync(model.HospitalIdNumber);
            if (isIdTaken)
            {
                ModelState.AddModelError(nameof(model.HospitalIdNumber),
                    "Pharmacist with the provided Hospital ID already exists!");
            }

            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.pharmacistService.Create(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured while attempting to register you as a partner! " +
                    "Please try again later or contact administrator!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("Drug", "All");
        }

        [HttpPost]
        public async Task<IActionResult> Prescribe(string id)
        {
            return this.Ok();
        }
    }
}

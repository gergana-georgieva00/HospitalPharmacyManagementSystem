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
        private readonly IDrugService drugService;

        public PharmacistController(IPharmacistService pharmacistService, IDrugService drugService)
        {
            this.pharmacistService = pharmacistService;
            this.drugService = drugService;
        }

        [HttpGet]
        public async Task<IActionResult> BecomePharmacist()
        {
            string userId = this.User.GetId()!;
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

        //[HttpGet]
        //public async Task<IActionResult> Prescribe()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Prescribe(string id)//, PrescribeFormModel model)
        {
            bool drugExists = await this.drugService
                .ExistsByIdAsync(id);
            string userId = this.User.GetId()!;
            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(userId);
            ViewBag.IsUserPharmacist = isUserPharmacist;

            if (!drugExists)
            {
                TempData[ErrorMessage] = "Drug with provided id does not exist! " +
                    "Please try again or add it to the System!";

                return RedirectToAction("All", "Drug");
            }

            try
            {
                await pharmacistService.PrescribeDrugAsync(id, User.GetId()!);
                //PrescribeFormModel model = await this.pharmacistService
                //    .
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured while attempting to prescribe the drug! " +
                    "Please try again later or contact administrator!";

                return this.RedirectToAction("Index", "Home");
            }

            return RedirectToAction("All", "Drug");
        }
    }
}

namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    using HospitalPharmacyManagementSystem.Services.Data;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist;
    using HospitalPharmacyManagementSytem.Web.Infrastucture.Extensions;
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
            string userId = this.User.GetId()!;
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

            return this.RedirectToAction("All", "Drug");
        }

        [HttpGet]
        public async Task<IActionResult> Prescribe()
        {
            string userId = this.User.GetId()!;
            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(userId);
            ViewBag.IsUserPharmacist = isUserPharmacist;

            try
            {
                PrescribeFormModel model = new PrescribeFormModel
                {
                    Drugs = await this.drugService.AllDrugsAsync()
                };

                return View(model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to update the drug!" +
                    "Please try again or contact administrator!");
                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Prescribe(/*string id, */PrescribeFormModel model)
        {
            //bool drugExists = await this.drugService
            //    .ExistsByIdAsync(id);
            string userId = this.User.GetId()!;
            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(userId);
            ViewBag.IsUserPharmacist = isUserPharmacist;

            bool userExists = await
                this.pharmacistService.PatientExistsByEmailAsync(model.PatientEmail);

            if (!userExists)
            {
                ModelState.AddModelError(nameof(model.PatientEmail),
                    "Patient with the provided email does not exist in the system!");
            }

            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            try
            {


                string? pharmacistId =
                   await this.pharmacistService.GetPharmacistIdByUserIdAsync(this.User.GetId()!);

                TempData[SuccessMessage] = "Prescription was added successfully!";
                await this.pharmacistService.PrescribeDrugAsync(model, userId);
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

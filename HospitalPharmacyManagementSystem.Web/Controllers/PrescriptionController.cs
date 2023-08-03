using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
using HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist;
using HospitalPharmacyManagementSytem.Web.Infrastucture.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HospitalPharmacyManagementSystem.Common.NotificationMessages;


namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    [Authorize]
    public class PrescriptionController : Controller
    {
        private readonly IPharmacistService pharmacistService;
        private readonly IDrugService drugService;

        public PrescriptionController(IPharmacistService pharmacistService, IDrugService drugService)
        {
            this.pharmacistService = pharmacistService;
            this.drugService = drugService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> PrescriptionDetails(string id)
        {
            //bool drugExists = await this.drugService.ExistsByIdAsync(id);
            string userId = this.User.GetId()!;
            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(userId);
            ViewBag.IsUserPharmacist = isUserPharmacist;

            //if (!drugExists)
            //{
            //    this.TempData[ErrorMessage] = "Drug with the provided id does not exist!";
            //    return this.RedirectToAction("All", "Drug");
            //}

            try
            {
                PrescriptionViewModel viewModel = await this.drugService
                .GetPrescriptionByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while trying to update the drug!" +
                    "Please try again or contact administrator!";
                return this.RedirectToAction("All", "Drug");
            }
        }
    }
}

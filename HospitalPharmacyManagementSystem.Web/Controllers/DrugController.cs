﻿namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
    using HospitalPharmacyManagementSytem.Web.Infrastucture.Extentions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using static Common.NotificationMessages;

    [Authorize]
    public class DrugController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPharmacistService pharmacistService;

        public DrugController(ICategoryService categoryService, IPharmacistService pharmacistService)
        {
            _categoryService = categoryService;
            this.pharmacistService = pharmacistService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return RedirectToAction("Index", "Home");
            //return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(this.User.GetId()!);

            if (!isPharmacist)
            {
                this.TempData[ErrorMessage] = "You must be a partner in order to add new Drug to the system!";
                return this.RedirectToAction("BecomePharmacist", "Pharmacist");
            }

            AddDrugViewModel model = new AddDrugViewModel()
            {
                Categories = await this._categoryService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDrugViewModel model)
        {

        }
    }
}

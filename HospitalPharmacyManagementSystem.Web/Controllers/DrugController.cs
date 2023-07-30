namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    using HospitalPharmacyManagementSystem.Services.Data.Models.Drug;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist;
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
        private readonly IDrugService drugService;

        public DrugController(ICategoryService categoryService, IPharmacistService pharmacistService, IDrugService drugService)
        {
            _categoryService = categoryService;
            this.pharmacistService = pharmacistService;
            this.drugService = drugService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllDrugsQueryModel queryModel)
        {
            AllDrugsFilteredAndPagedServiceModel serviceModel =
                await this.drugService.AllAsync(queryModel);

            string userId = this.User.GetId()!;
            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(userId);
            ViewBag.IsUserPharmacist = isUserPharmacist;
            queryModel.Drugs = serviceModel.Drugs;
            queryModel.TotalDrugs = serviceModel.TotalDrugsCount;
            queryModel.Categories = await this._categoryService.AllCategoryNamesAsync();

            return this.View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            IEnumerable<PrescribeFormModel> myDrugs = new List<PrescribeFormModel>();
            string userId = this.User.GetId()!;
            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(userId);
            ViewBag.IsUserPharmacist = isUserPharmacist;

            try
            {
                var drugs = await this.drugService.AllByUserIdAsync(userId);
                return this.View(drugs);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred!" +
                    "Please try again or contact administrator!";
                return this.RedirectToAction("All", "Drug");
            }
            
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool drugExists = await this.drugService.ExistsByIdAsync(id);
            string userId = this.User.GetId()!;
            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(userId);
            ViewBag.IsUserPharmacist = isUserPharmacist;

            if (!drugExists)
            {
                this.TempData[ErrorMessage] = "Drug with the provided id does not exist!";
                return this.RedirectToAction("All", "Drug");
            }

            try
            {
                DrugDetailsViewModel viewModel = await this.drugService
                .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while trying to update the drug!" +
                    "Please try again or contact administrator!";
                return this.RedirectToAction("All", "Drug");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool drugExists = await this.drugService.ExistsByIdAsync(id);

            if (!drugExists)
            {
                this.TempData[ErrorMessage] = "Drug with the provided id does not exist!";
                return this.RedirectToAction("Index", "Home");
            }

            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserPharmacist)
            {
                this.TempData[ErrorMessage] = "You must be registered as a pharmacist in order to edit drug info!";
                return this.RedirectToAction("Become", "Pharmacist");
            }

            try
            {
                AddDrugViewModel formModel = await this.drugService
                .GetDrugForEditByIdAsync(id);
                formModel.Categories = await this._categoryService
                    .AllCategoriesAsync();

                return this.View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while trying to update the drug!" +
                    "Please try again or contact administrator!";
                return this.RedirectToAction("All", "Drug");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, AddDrugViewModel formModel)
        {
            if (!this.ModelState.IsValid)
            {
                formModel.Categories = await this._categoryService.AllCategoriesAsync();
                return this.View(formModel);
            }

            try
            {
                await this.drugService.EditDrugByIdAndFormModelAsync(id, formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to update the drug!" +
                    "Please try again or contact administrator!");
                formModel.Categories = await this._categoryService.AllCategoriesAsync();

                return this.View(formModel);
            }

            TempData[SuccessMessage] = "Drug was edited successfully!";
            return this.RedirectToAction("Details", "Drug", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string userId = this.User.GetId()!;
            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(userId);
            ViewBag.IsUserPharmacist = isUserPharmacist;

            if (!isUserPharmacist)
            {
                this.TempData[ErrorMessage] = "You must be a partner in order to add new Drug to the system!";
                return this.RedirectToAction("BecomePharmacist", "Pharmacist");
            }

            try
            {
                AddDrugViewModel model = new AddDrugViewModel()
                {
                    Categories = await this._categoryService.AllCategoriesAsync()
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
        public async Task<IActionResult> Add(AddDrugViewModel model)
        {
            bool isPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(this.User.GetId()!);

            if (!isPharmacist)
            {
                this.TempData[ErrorMessage] = "You must be a partner in order to add new Drug to the system!";
                return this.RedirectToAction("BecomePharmacist", "Pharmacist");
            }

            bool categoryExists = await this._categoryService
                .ExistsByIdAsync(model.CategoryId);

            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Seelcted category does not exist!");
            }

            if (ModelState.IsValid)
            {
                model.Categories = await this._categoryService.AllCategoriesAsync();
                return View(model);
            }

            try
            {
                string? pharmacistId =
                    await this.pharmacistService.GetPharmacistIdByUserIdAsync(this.User.GetId()!);

                TempData[SuccessMessage] = "Drug was added successfully!";
                await this.drugService.CreateAsync(model, pharmacistId!);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add new drug!" +
                    "Please try again or contact administrator!");

                return this.View(model);
            }

            return this.RedirectToAction("All", "Drug");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool drugExists = await this.drugService.ExistsByIdAsync(id);

            if (!drugExists)
            {
                this.TempData[ErrorMessage] = "Drug with the provided id does not exist!";
                return this.RedirectToAction("Index", "Home");
            }

            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserPharmacist)
            {
                this.TempData[ErrorMessage] = "You must be registered as a pharmacist in order to edit drug info!";
                return this.RedirectToAction("Become", "Pharmacist");
            }

            try
            {
                DrugPreDeleteViewModel viewModel= await this.drugService
                    .GetDrugForDeleteByIdAsync(id);

                return View(viewModel);
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
        public async Task<IActionResult> Delete(string id, DrugPreDeleteViewModel model)
        {
            bool drugExists = await this.drugService.ExistsByIdAsync(id);

            if (!drugExists)
            {
                this.TempData[ErrorMessage] = "Drug with the provided id does not exist!";
                return this.RedirectToAction("Index", "Home");
            }

            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserPharmacist)
            {
                this.TempData[ErrorMessage] = "You must be registered as a pharmacist in order to edit drug info!";
                return this.RedirectToAction("Become", "Pharmacist");
            }

            try
            {
                await this.drugService.DeleteDrugByIdAsync(id);

                this.TempData[WarningMessage] = "Drug deleted successfully!";
                return this.RedirectToAction("Mine", "Drug");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to delete the drug from the system!" +
                    "Please try again or contact administrator!");
                return this.RedirectToAction("Index", "Home");
            }
        }
    }
}

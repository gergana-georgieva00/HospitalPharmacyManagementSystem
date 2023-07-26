namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    using HospitalPharmacyManagementSystem.Services.Data.Models.Drug;
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

            queryModel.Drugs = serviceModel.Drugs;
            queryModel.TotalDrugs = serviceModel.TotalDrugsCount;
            queryModel.Categories = await this._categoryService.AllCategoryNamesAsync();

            return this.View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<DrugAllViewModel> myDrugs = new List<DrugAllViewModel>();
            string userId = this.User.GetId()!;

            bool isUserPharmacist = await this.pharmacistService
                .PharmacistExistsByUserIdAsync(userId);

            var drugs = await this.drugService.AllByUserIdAsync(userId);
            return this.View(drugs);
            if (isUserPharmacist)
            {
                // should redirect or display message
            }
            else
            {
                
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool drugExists = await this.drugService.ExistsByIdAsync(id);

            if (!drugExists)
            {
                this.TempData[ErrorMessage] = "House with the provided id does not exist!";
                return this.RedirectToAction("All", "Drug");
            }

            DrugDetailsViewModel viewModel = await this.drugService
                .GetDetailsByIdAsync(id);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

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
    }
}

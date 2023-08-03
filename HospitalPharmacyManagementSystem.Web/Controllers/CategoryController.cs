namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    using HospitalPharmacyManagementSytem.Web.Infrastucture.Extensions;
    using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Category;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Web.Infrastructure.Extensions;
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AllCategoriesViewModel> viewModel = await categoryService
                .AllCategoriesForListAsync();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            bool categoryExists = await categoryService.ExistsByIdAsync(id);
            if (!categoryExists)
            {
                return NotFound();
            }

            CategoryDetailsViewModel viewModel =
                await categoryService.GetDetailsByIdAsync(id);
            if (viewModel.GetUrlInformation() != information)
            {
                return NotFound();
            }

            return View(viewModel);
        }
    }
}

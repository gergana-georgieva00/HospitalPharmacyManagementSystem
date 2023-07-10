namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DrugController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return RedirectToAction("Index", "Home");
            //return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

        }
    }
}

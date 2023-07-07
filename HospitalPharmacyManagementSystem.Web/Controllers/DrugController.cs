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
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPharmacyManagementSystem.Web.Controllers
{
    [Authorize]
    public class PharmacistController : Controller
    {
        public async Task<IActionResult> BecomePharmacist()
        {
            return View();
        }
    }
}

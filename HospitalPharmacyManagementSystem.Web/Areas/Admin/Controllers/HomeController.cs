using Microsoft.AspNetCore.Mvc;

namespace HospitalPharmacyManagementSystem.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Indexx()
        {
            return View();
        }
    }
}

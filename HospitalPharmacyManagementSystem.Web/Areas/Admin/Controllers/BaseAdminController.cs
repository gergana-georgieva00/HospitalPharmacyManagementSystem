using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HospitalPharmacyManagementSystem.Common.GeneralAppConstants;

namespace HospitalPharmacyManagementSystem.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
using HospitalPharmacyManagementSystem.Web.Areas.Admin.ViewModels.Drug;
using HospitalPharmacyManagementSytem.Web.Infrastucture.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPharmacyManagementSystem.Web.Areas.Admin.Controllers
{
    public class DrugController : BaseAdminController
    {
        private readonly IPharmacistService pharmacistService;
        private readonly IDrugService drugService;

        public DrugController(IPharmacistService pharmacistService, IDrugService drugService)
        {
            this.pharmacistService = pharmacistService;
            this.drugService = drugService;
        }

        public async Task<IActionResult> Mine()
        {
            var pharmacistId = await this.pharmacistService
                .GetPharmacistIdByUserIdAsync(this.User.GetId()!);

            MyDrugsViewModel model = new MyDrugsViewModel()
            {
                PrescribedDrugs = await this.drugService.AllByUserIdAsync(pharmacistId!)
            };

            return this.View(model);
        }
    }
}

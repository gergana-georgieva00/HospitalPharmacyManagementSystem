using HospitalPharmacyManagementSystem.Web.ViewModels.Category.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPharmacyManagementSytem.Web.Infrastucture.Extentions
{
    public static class ViewModelsExtensions
    {
        public static string GetUrlInformation(this ICategoryDetailsModel model)
        {
            return model.Name.Replace(" ", "-");
        }
    }
}

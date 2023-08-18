using HospitalPharmacyManagementSystem.Web.ViewModels.Disease;
using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPharmacyManagementSystem.Services.Data.Interfaces
{
    public interface IDiseaseService
    {
        Task<IEnumerable<SelectDiseaseViewModel>> AllDiseasesAsync();
    }
}

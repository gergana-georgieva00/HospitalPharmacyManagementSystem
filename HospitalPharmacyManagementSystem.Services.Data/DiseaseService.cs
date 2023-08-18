using HospitalPharmacyManagementSystem.Data;
using HospitalPharmacyManagementSystem.Services.Data.Interfaces;
using HospitalPharmacyManagementSystem.Web.ViewModels.Disease;
using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPharmacyManagementSystem.Services.Data
{
    public class DiseaseService : IDiseaseService
    {
        private readonly HospitalPharmacyManagementSystemDbContext dbContext;

        public DiseaseService(HospitalPharmacyManagementSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<SelectDiseaseViewModel>> AllDiseasesAsync()
        {
            IEnumerable<SelectDiseaseViewModel> allDiseases =
                await this.dbContext
                .Diseases
                .AsNoTracking()
                .Select(d => new SelectDiseaseViewModel()
                {
                    Id = d.Id.ToString(),
                    Name = d.Name
                })
                .ToArrayAsync();

            return allDiseases;
        }
    }
}

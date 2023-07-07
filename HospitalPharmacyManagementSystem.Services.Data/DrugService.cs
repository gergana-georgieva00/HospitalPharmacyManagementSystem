namespace HospitalPharmacyManagementSystem.Services.Data
{
    using HospitalPharmacyManagementSystem.Web.Data;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Home;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.ViewModels;

    public class DrugService : IDrugService
    {
        private readonly HospitalPharmacyManagementSystemDbContext dbContext;

        public DrugService(HospitalPharmacyManagementSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> BestDealsAsync()
        {
             IEnumerable<IndexViewModel> fiveBestDeals = await this.dbContext
                .Drugs
                .OrderBy(d => d.Price)
                .Take(5)
                .Select(d => new IndexViewModel() 
                { 
                    Id = d.Id.ToString(),
                    BrandName = d.BrandName,
                    ImageUrl = d.ImageUrl
                })
                .ToArrayAsync();

            return fiveBestDeals;
        }
    }
}

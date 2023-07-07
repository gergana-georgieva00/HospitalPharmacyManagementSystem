namespace HospitalPharmacyManagementSystem.Services.Data
{
    using HospitalPharmacyManagementSystem.Web.Data;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Home;
    using Interfaces;
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

        public Task<IEnumerable<IndexViewModel>> MostPrescribed()
        {
            throw new NotImplementedException();
        }
    }
}

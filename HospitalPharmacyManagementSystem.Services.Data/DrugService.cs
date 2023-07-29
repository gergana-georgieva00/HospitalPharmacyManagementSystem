namespace HospitalPharmacyManagementSystem.Services.Data
{
    using HospitalPharmacyManagementSystem.Common.Enums;
    using HospitalPharmacyManagementSystem.Data.Models;
    using HospitalPharmacyManagementSystem.Services.Data.Models.Drug;
    using HospitalPharmacyManagementSystem.Web.Data;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug.Enums;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Home;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //using static HospitalPharmacyManagementSystem.Common.EntityValidationConstants;

    public class DrugService : IDrugService
    {
        private readonly HospitalPharmacyManagementSystemDbContext dbContext;

        public DrugService(HospitalPharmacyManagementSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllDrugsFilteredAndPagedServiceModel> AllAsync(AllDrugsQueryModel queryModel)
        {
            IQueryable<Drug> drugsQuery = this.dbContext
                .Drugs
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                drugsQuery = drugsQuery
                    .Where(h => h.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                drugsQuery = drugsQuery
                    .Where(h => EF.Functions.Like(h.BrandName, wildCard) ||
                                EF.Functions.Like(h.Description, wildCard));
            }

            drugsQuery = queryModel.DrugSorting switch
            {
                DrugSorting.Newest => drugsQuery
                    .OrderByDescending(h => h.CreatedOn),
                DrugSorting.Oldest => drugsQuery
                    .OrderBy(h => h.CreatedOn),
                DrugSorting.PriceAscending => drugsQuery
                    .OrderBy(h => h.Price),
                DrugSorting.PriceDescending => drugsQuery
                    .OrderByDescending(h => h.Price),
                _ => drugsQuery
                    //.OrderBy(h => h.RenterId != null)
                    .OrderByDescending(h => h.CreatedOn)
            };

            IEnumerable<DrugAllViewModel> allDrugs = await drugsQuery
                .Where(d => d.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.DrugsPerPage)
                .Take(queryModel.DrugsPerPage)
                .Select(d => new DrugAllViewModel
                {
                    Id = d.Id.ToString(),
                    BrandName = d.BrandName,
                    ImageUrl = d.ImageUrl,
                    Price = d.Price
                })
                .ToArrayAsync();
            int totalDrugs = drugsQuery.Count();
            var testCountAllDrugs = allDrugs.Count();
            var firstDrug = allDrugs.FirstOrDefault();
            return new AllDrugsFilteredAndPagedServiceModel()
            {
                TotalDrugsCount = totalDrugs,
                Drugs = allDrugs
            };
        }

        public async Task<IEnumerable<DrugAllViewModel>> AllByUserIdAsync(string userId)
        {
            //var drugs = await this.dbContext
            //   .Users
            //   .Where(u => u.Id.ToString() == userId)
            //   .Select(u => u.Prescriptions
            //            .Select(d => new DrugAllViewModel
            //            {
            //                Id = d.Id.ToString(),
            //                BrandName = d.BrandName,
            //                Description = d.Description,
            //                ImageUrl = d.ImageUrl,
            //                Price = d.Price
            //            }))
            //   .SingleOrDefaultAsync();

            //return drugs;

            IEnumerable<DrugAllViewModel> allUserDrugs = await dbContext
                .Drugs
                .Where(d => d.IsActive &&
                            d.Patients.Any(p => p.Id.ToString() == userId))
                .Select(d => new DrugAllViewModel
                {
                    Id = d.Id.ToString(),
                    BrandName = d.BrandName,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    Price = d.Price
                })
                .ToArrayAsync();

            return allUserDrugs;
        }

        //private  IEnumerable<DrugAllViewModel> GetAllDrugs(string userId)
        //{
        //    IQueryable<Drug> drugsQuery = dbContext
        //        .Users
        //        .Where(u => u.Id.ToString() == userId)
        //        .Select(u => u.Prescriptions);

        //    foreach (var drug in dbContext.Users
        //               .Where(u => u.Id.ToString() == userId).FirstAsync().Prescriptions)
        //    {
        //        yield return new DrugAllViewModel()
        //        {
        //            Id = drug.Id.ToString(),
        //            BrandName = drug.BrandName,
        //            Description = drug.Description,
        //            ImageUrl = drug.ImageUrl,
        //            Price = drug.Price
        //        };
        //    }
        //}

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

        public async Task CreateAsync(AddDrugViewModel formModel, string pharmacistId)
        {
            Drug newDrug = new Drug()
            {
                BrandName = formModel.BrandName,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.PricePerPackage,
                CategoryId = formModel.CategoryId,
                PharmacistId = Guid.Parse(pharmacistId)
            };

            await this.dbContext.Drugs.AddAsync(newDrug);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteDrugByIdAsync(string drugId)
        {
            Drug drugToDelete = await this.dbContext
                .Drugs
                .Where(d => d.IsActive == true)
                .FirstAsync(d => d.Id.ToString() == drugId);

            drugToDelete.IsActive = false;
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditDrugByIdAndFormModelAsync(string drugId, AddDrugViewModel formModel)
        {
            Drug drug = await this.dbContext
                .Drugs
                .Where(d => d.IsActive)
                .FirstAsync(d => d.Id.ToString() == drugId);

            drug.BrandName = formModel.BrandName;
            drug.Description = formModel.Description;
            drug.ImageUrl = formModel.ImageUrl;
            drug.Price = formModel.PricePerPackage;
            //drug.Form = Enum.TryParse(formModel.DrugForm, DrugForm, );
            drug.Form = Enum.Parse<DrugForm>(formModel.DrugForm);
            drug.CategoryId = formModel.CategoryId;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string drugId)
        {
            var result = await this.dbContext
                .Drugs
                .Where(d => d.IsActive)
                .AnyAsync(d => d.Id.ToString() == drugId);

            return result;
        }

        public async Task<DrugDetailsViewModel> GetDetailsByIdAsync(string drugId)
        {
            Drug drug = await this.dbContext
                .Drugs
                .Where(d => d.IsActive)
                .FirstAsync(d => d.Id.ToString() == drugId);

            var drugCategory = await dbContext.Categories.Where(c => c.Id == drug.CategoryId).SingleAsync();

            return new DrugDetailsViewModel
            {
                Id = drug.Id.ToString(),
                BrandName = drug.BrandName,
                Description = drug.Description,
                ImageUrl = drug.ImageUrl,
                Price = drug.Price,
                Category = drugCategory.Name,
                Form = drug.Form.ToString()
            };
        }

        public async Task<DrugPreDeleteViewModel> GetDrugForDeleteByIdAsync(string drugId)
        {
            Drug drug = await this.dbContext
                .Drugs
                .Where(d => d.IsActive)
                .FirstAsync(d => d.Id.ToString() == drugId);

            return new DrugPreDeleteViewModel
            {
                BrandName = drug.BrandName,
                Description = drug.Description,
                ImageUrl = drug.ImageUrl
            };
        }

        public async Task<AddDrugViewModel> GetDrugForEditByIdAsync(string drugId)
        {
            Drug drug = await this.dbContext
                .Drugs
                .Where(d => d.IsActive)
                .FirstAsync(d => d.Id.ToString() == drugId);

            var drugCategory = await dbContext.Categories.Where(c => c.Id == drug.CategoryId).SingleAsync();

            return new AddDrugViewModel
            {
                BrandName = drug.BrandName,
                Description = drug.Description,
                ImageUrl = drug.ImageUrl,
                PricePerPackage = drug.Price,
                CategoryId = drug.Category.Id,
                DrugForm = drug.Form.ToString()
            };
        }
    }
}

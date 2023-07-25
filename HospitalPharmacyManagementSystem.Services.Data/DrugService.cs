namespace HospitalPharmacyManagementSystem.Services.Data
{
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
                //.Where(d => d.IsActive)
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

            return new AllDrugsFilteredAndPagedServiceModel()
            {
                TotalDrugsCount = totalDrugs,
                Drugs = allDrugs
            };
        }

        public async Task<IEnumerable<DrugAllViewModel>> AllByUserIdAsync(string userId)
        {
            var drugs = await this.dbContext
               .Users
               .Where(u => u.Id.ToString() == userId)
               .Select(u => u.Prescriptions
                        .Select(d => new DrugAllViewModel
                        {
                            Id = d.Id.ToString(),
                            BrandName = d.BrandName,
                            Description = d.Description,
                            ImageUrl = d.ImageUrl,
                            Price = d.Price
                        }))
               .SingleOrDefaultAsync();

            //if (drugs is null)
            //{
            //    return null;
            //}

            return drugs;
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

        public async Task<DrugDetailsViewModel> GetDetailsByIdAsync(string drugId)
        {
            Drug drug = await this.dbContext.Drugs
                .FirstAsync(d => d.Id.ToString() == drugId);

            var drugCategory = await dbContext.Categories.Where(c => c.Id == drug.CategoryId).SingleAsync();

            return new DrugDetailsViewModel
            {
                Id = drug.Id.ToString(),
                BrandName = drug.BrandName,
                Description = drug.Description,
                ImageUrl = drug.ImageUrl,
                Price = drug.Price,
                Category = drugCategory.Name,//drug.Category.Name,
                Form = drug.Form.ToString()
            };
        }
    }
}

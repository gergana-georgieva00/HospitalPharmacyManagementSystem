namespace HospitalPharmacyManagementSystem.Services.Data
{
    using HospitalPharmacyManagementSystem.Common.Enums;
    using HospitalPharmacyManagementSystem.Data;
    using HospitalPharmacyManagementSystem.Data.Models;
    using HospitalPharmacyManagementSystem.Services.Data.Models.Drug;
    using HospitalPharmacyManagementSystem.Services.Data.Models.Statistics;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Category;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug.Enums;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Home;
    using HospitalPharmacyManagementSystem.Web.ViewModels.Pharmacist;
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

        public async Task<IEnumerable<PrescriptionViewModel>> AllByUserIdAsync(string userId)
        {
            IEnumerable<PrescriptionViewModel> allPrescriptions = await this.dbContext
                .Prescriptions
                .Where(p => p.PatientId.ToString() == userId)
                .OrderBy(p => p.CreatedOn)
                .Select(p => new PrescriptionViewModel
                {
                    Id = p.Id.ToString(),
                    PharmacistId = p.PharmacistId.ToString(),
                    PatientEmail = p.Patient.Email,
                    CreatedOn = p.CreatedOn,
                    DrugBrandName = p.Medication.BrandName,
                    DiseaseName = p.Disease.Name,
                    ValidUntil = p.ValidUntil,
                    MedicationFrequency = p.MedicationFrequency,
                    Notes = p.Notes
                }).ToListAsync();

            return allPrescriptions;
        }

        public async Task<IEnumerable<SelectDrugViewModel>> AllDrugsAsync()
        {
            IEnumerable<SelectDrugViewModel> allDrugs =
                await this.dbContext
                .Drugs
                .AsNoTracking()
                .Select(d => new SelectDrugViewModel()
                {
                    Id = d.Id.ToString(),
                    BrandName = d.BrandName
                })
                .ToArrayAsync();

            return allDrugs;
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

        public async Task CreateAsync(AddDrugViewModel formModel, string pharmacistId)
        {
            Drug newDrug = new Drug()
            {
                BrandName = formModel.BrandName,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.PricePerPackage,
                CategoryId = formModel.CategoryId,
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

        public async Task<PrescriptionViewModel> GetPrescriptionByIdAsync(string id)
        {
            var prescription = await this
                .dbContext
                .Prescriptions
                .Where(p => p.Id.ToString() == id)
                .FirstAsync();

                var user = await this.dbContext
                .Users
                .Where(u => u.Id == prescription.PatientId)
                .FirstAsync();

            var medication = await this.dbContext
                .Drugs
                .Where(d => d.Id == prescription.MedicationId)
                .FirstAsync();

            var disease = await this.dbContext
                .Diseases
                .Where(d => d.Id == prescription.DiseaseId)
                .FirstAsync();

            return new PrescriptionViewModel
                {
                    Id = id,
                    PharmacistId = prescription.PharmacistId.ToString(),
                    PatientEmail = user.Email,
                    CreatedOn = prescription.CreatedOn,
                    ValidUntil = prescription.ValidUntil,
                    DrugBrandName = medication.BrandName,
                    DiseaseName = disease.Name,
                    MedicationFrequency = prescription.MedicationFrequency,
                    Notes = prescription.Notes
                };
        }

        public async Task<StatisticsServiceModel> GetStatisticsAsync()
        {
            return new StatisticsServiceModel()
            {
                TotalDrugs = await this.dbContext.Drugs.CountAsync(),
                TotalPrescriptions = await this.dbContext.Prescriptions.CountAsync()
            };
        }
    }
}

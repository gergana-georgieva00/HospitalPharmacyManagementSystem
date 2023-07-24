namespace HospitalPharmacyManagementSystem.Web.ViewModels.Drug
{
    using HospitalPharmacyManagementSystem.Web.ViewModels.Drug.Enums;
    using System.ComponentModel.DataAnnotations;
    using static Common.GeneralAppConstants;
    using Enums;

    public class AllDrugsQueryModel
    {
        public AllDrugsQueryModel()
        {
            CurrentPage = DefaultPage;
            DrugsPerPage = EntitiesPerPage;

            Categories = new HashSet<string>();
            Drugs = new HashSet<DrugAllViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Drugs By")]
        public DrugSorting DrugSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Drugs On Page")]
        public int DrugsPerPage { get; set; }

        public int TotalDrugs { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<DrugAllViewModel> Drugs { get; set; }
    }
}

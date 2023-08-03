namespace HospitalPharmacyManagementSystem.Web.ViewModels.Category
{
    using HospitalPharmacyManagementSystem.Web.ViewModels.Category.Interfaces;

    public class CategoryDetailsViewModel : ICategoryDetailsModel
    {
        public string Name { get; set; } = null!;
        public int Id { get; set; }
    }
}

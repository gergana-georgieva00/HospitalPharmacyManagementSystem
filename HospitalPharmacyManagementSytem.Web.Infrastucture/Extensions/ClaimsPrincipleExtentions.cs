namespace HospitalPharmacyManagementSytem.Web.Infrastucture.Extensions
{
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    using System.Security.Claims;
    using static HospitalPharmacyManagementSystem.Common.GeneralAppConstants;
    public static class ClaimsPrincipleExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName);
        }
    }
}

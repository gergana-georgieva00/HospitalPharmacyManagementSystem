using System.Security.Claims;

namespace HospitalPharmacyManagementSytem.Web.Infrastucture.Extentions
{
    public static class ClaimsPrincipleExtentions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

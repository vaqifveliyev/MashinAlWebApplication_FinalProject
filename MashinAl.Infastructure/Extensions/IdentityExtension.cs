using System.Security.Claims;

namespace MashinAl.Infastructure.Extensions
{
    public static partial class Extension
    {
        public static string GetClaimValue(this ClaimsPrincipal principal, string type)
        {
            return principal.Claims.FirstOrDefault(m => m.Type.Equals(type)).Value;
        }

        // View'larda if şərti verilir => (  @if(User.HasClaim("admin.dashboard.index")  ) <= hər view-un öz controller və action-u!
        public static bool HasClaim(this ClaimsPrincipal principal, string type)
        {
            return principal.Claims.Any(m => m.Type.Equals(type)) || principal.IsInRole("superadmin");
        }
    }
}

using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace FinancialServices.Extensions
{
    public static class ClaimPrincipleExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);

        }



    }
}

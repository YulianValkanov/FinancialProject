using Microsoft.AspNetCore.Identity;

namespace FinancialServices.Data.Models
{
    public class User : IdentityUser
    {
        public string? Position { get; set; }
    }
}

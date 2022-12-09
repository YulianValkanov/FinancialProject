using Microsoft.Build.Framework;

namespace FinancialServices.Models.Companies
{
    public class AddCompaniesViewModel
    {
        [Required]
        public long IdEik { get; set; }
        [Required]
        public string CompanyName { get; set; }

        public string? AddressCompany { get; set; }

        public string? AddressActivity { get; set; }

        public string? KidNumber { get; set; }

        public string? Representing { get; set; }

        public string? TypeRepresenting { get; set; }

        public string? TypeCompany { get; set; }

        public string? ContactName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Status { get; set; }


    }
}

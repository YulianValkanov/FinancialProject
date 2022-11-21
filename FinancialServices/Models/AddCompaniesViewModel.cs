using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Data.Models;
using FinancialServices.Data.Models;

namespace FinancialServices.Models
{
    public class AddCompaniesViewModel
    {
       
        public long IdEik { get; set; }

        public string? CompanyName { get; set; }

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

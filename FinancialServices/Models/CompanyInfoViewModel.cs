using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Data.Models;
using FinancialServices.Data.Models;

namespace FinancialServices.Models
{
    public class CompanyInfoViewModel
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


        public List<Person>? Managers { get; set; }

        public List<Person> OwnersPersons { get; set; } = new List<Person>();

        public List<MapingOwnerCompany> OwnersCompaniesData { get; set; } = new List<MapingOwnerCompany>();

        public List<Company> OwnersCompanies { get; set; } = new List<Company>();

        public List<ReportData> Reports { get; set; } = new List<ReportData>();




    }
}

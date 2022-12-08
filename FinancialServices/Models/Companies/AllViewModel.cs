using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Data.Models;

namespace FinancialServices.Models.Companies
{
    public class AllViewModel
    {

        public long IdEik { get; set; }

        public string? CompanyName { get; set; }

        public string? KidNumber { get; set; }

        public string? Group { get; set; }

        public string? GroupName { get; set; }

        public string? PositionName { get; set; }







    }
}

using System.ComponentModel;

namespace FinancialServices.Models
{
    public class AllQueryModel
    {
        [DisplayName("ЕИК")]
        public string? Eik { get; set; }

        [DisplayName("Фирма")]
        public string? CompanyName { get; set; }

        [DisplayName("КИД")]
        public string? Kid { get; set; }


        public IEnumerable<AllViewModel> Companyes { get; set; } = Enumerable.Empty<AllViewModel>();


    }
}

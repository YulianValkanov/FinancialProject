using System.ComponentModel;

namespace FinancialServices.Models.Companies
{
    public class AllQueryModel
    {



        [DisplayName("ЕИК")]
        public long? Eik { get; set; }

        [DisplayName("Фирма")]
        public string? CompanyName { get; set; }


        [DisplayName("Група по КИД (N..N..N)")]
        public string? Group { get; set; }

        [DisplayName("КИД номера (N..N..N)")]
        public string? Kid { get; set; }



        public IEnumerable<AllViewModel> Companyes { get; set; } = Enumerable.Empty<AllViewModel>();


    }
}

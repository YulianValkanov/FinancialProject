using FinancialServices.Models.Companies;
using System.ComponentModel;

namespace FinancialServices.Models.Persons
{
    public class AllQuaryPersonViewModel
    {
        [DisplayName("ЕГН")]
        public long IdEgn { get; set; }

        [DisplayName("Име")]
        public string? FirstName { get; set; }

        [DisplayName("Презиме")]
        public string? SecondName { get; set; }

        [DisplayName("Фамилия")]
        public string? LastName { get; set; }


        public IEnumerable<AllPersonViewModel> Persons { get; set; } = Enumerable.Empty<AllPersonViewModel>();
    }
}

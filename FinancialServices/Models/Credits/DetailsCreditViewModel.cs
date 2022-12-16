

namespace FinancialServices.Models.Credits
{
    public class DetailsCreditViewModel 
    {

        public string CompanyName { get; set; }

        public long IdEik { get; set; }

        public IEnumerable<CreditViewModel> Credits { get; set; } = Enumerable.Empty<CreditViewModel>();



    }
}

namespace FinancialServices.Models.Reports
{
    public class DetailsPnlViewModel
    {

        public string CompanyName { get; set; }

        public long IdEik { get; set; }

        public IEnumerable<PnlViewModel> Reports { get; set; } = Enumerable.Empty<PnlViewModel>();
    }
}

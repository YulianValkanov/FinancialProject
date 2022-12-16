using FinancialServices.Models.Companies;

namespace FinancialServices.Models.Reports
{
    public class DetailsReportViewModel 
    {

        public string CompanyName { get; set; }

        public long IdEik { get; set; }

        public IEnumerable<ReportViewModel> Reports { get; set; } = Enumerable.Empty<ReportViewModel>();



    }
}

namespace FinancialServices.Models.Reports
{
    public class AddReportViewModel
    {

        public long IdEik { get; set; }

        public int YearReport { get; set; }


        public double Assets { get; set; } = 0.0;

        public double CountOfEmployees { get; set; } = 0.0;

        public double AnnualTurnover { get; set; } = 0.0;



    }
}

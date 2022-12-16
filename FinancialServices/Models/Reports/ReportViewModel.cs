namespace FinancialServices.Models.Reports
{
    public class ReportViewModel
    {

        
        public int ReportId { get; set; }
   

        public long IdEik { get; set; }


        public int YearReport { get; set; }



        public double Assets { get; set; } = 0.0;

        public double CountOfEmployees { get; set; } = 0.0;

        public double AnnualTurnover { get; set; } = 0.0;



    }
}

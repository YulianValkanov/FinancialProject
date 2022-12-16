namespace FinancialServices.Models.Credits
{
    public class CreditViewModel
    {

        
        public int CreditId { get; set; }

        public long IdEik { get; set; }

        public int CreditNumber { get; set; }


        public double BeginValue { get; set; } = 0.0;

        public double Rate { get; set; } = 0.0;

        public double PresentValue { get; set; } = 0.0;



    }
}

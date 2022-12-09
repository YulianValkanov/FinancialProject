using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinancialServices.Models.Home
{
    public class CalculatorQueryModel
    {

        [DisplayName("Сума на кредита")]
        [Required]
        [Range(0.00, 1000000000.00, ErrorMessage = "Сумата на кредита трябва да бъде до {2} лева")]
        public double Amount { get; set; }

        [DisplayName("Годишен процент на разходите ГПР в %")]
        [Required]
        [Range(0.00, 100.00, ErrorMessage = "Процента е до {2} %")]
        public double Rate { get; set; }

        [DisplayName("Периоди в месеци")]
        [Required]
        [Range(0.00, 1200.00, ErrorMessage = "Месеците са ограничени до {2} %")]
        public int Periods { get; set; }

        [DisplayName("Вид погасителни вноски")]   
        public string CreditType { get; set; } = null!;


        public double Pmt { get; set; } = 0;

       

        public double Interests { get; set; } = 0;

        public double Principals { get; set; } = 0;

        public double AmountEnd { get; set; } = 0;

        public double FixPrincipals { get; set; } = 0;

        public double SumInterests { get; set; } = 0;

        public double SumParticipals { get; set; } = 0;

        public double SumPayment { get; set; } = 0;




    }
}

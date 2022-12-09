using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace FinancialServices.Models.Home
{
    public class CreditCalculatorViewModel
    {
        [Required]       
        [DisplayName("Сума на кредита")]
        [Range(0.00, 1000000000.00, ErrorMessage = "Сумата на кредита трябва да бъде до {2} лева")]

        public double Amount { get; set; }

        [Required]
      
        public double Rate { get; set; }

        [Required]
        [Range(0, 1200)]
        public int Periods { get; set; }

        [Required]
        public string CreditType { get; set; } = null!;


        public int Gratis { get; set; }


    }
}




using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialServices.Data.Models
{
    public class Credit
    {
        [Key]
        public int CreditId { get; set; }


        [Required]
        public long IdEik { get; set; }

        [Required]
        public int CreditNumber { get; set; }

       
        public double BeginValue { get; set; } = 0.0;

        public double Rate { get; set; } = 0.0;

        public double PresentValue { get; set; } = 0.0;

    }
}

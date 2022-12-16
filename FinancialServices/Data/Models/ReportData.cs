


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialServices.Data.Models
{
    public class ReportData
    {
        [Key]
        public int ReportId { get; set; }


        [Required]
        public long IdEik { get; set; }

        [Required]
        public int YearReport { get; set; }



        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long ReportId { get; set; }

        public double Assets { get; set; } = 0.0;

        public double CountOfEmployees { get; set; } = 0.0;

        public double AnnualTurnover { get; set; } = 0.0;

    }
}

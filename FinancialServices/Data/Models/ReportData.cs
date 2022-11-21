


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialServices.Data.Models
{
    public class ReportData
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ReportId { get; set; }

        public double Assets { get; set; } = 0.0;

        public double CountOfEmployees { get; set; } = 0.0;

        public double AnnualTurnover { get; set; } = 0.0;

    }
}

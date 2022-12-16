using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinancialServices.Areas.Administration.Data.DataProcessor.ImportDto
{
    public class ImportReportDto
    {
        [Key]
        public int ReportId { get; set; }


        [Required]
        public long IdEik { get; set; }

        [Required]
        public int YearReport { get; set; }

        [DefaultValue(0.0)]
        public double NumberEmployees2019 { get; set; }

        [DefaultValue(0.0)]
        public double AnnualTurnover2019 { get; set; }

        [DefaultValue(0.0)]
        public double Assets2019 { get; set; }
     

      


    }

}

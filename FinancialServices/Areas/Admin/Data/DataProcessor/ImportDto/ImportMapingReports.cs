using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinancialServices.Areas.Administration.Data.DataProcessor.ImportDto
{
    public class ImportMapingReports
    {


        [Required]
        public long IdEik { get; set; }

        [Required]
        public int ReportId { get; set; }
    
      

    }



}

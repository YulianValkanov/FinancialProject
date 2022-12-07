using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinancialServices.Areas.Administration.Data.DataProcessor.ImportDto
{
    public class ImportMapingManagersDto
    {


        [Required]
        public int IdEik { get; set; }
        [Required]
        public long IdEgn { get; set; }

    }




}

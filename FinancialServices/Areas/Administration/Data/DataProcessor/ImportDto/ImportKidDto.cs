using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinancialServices.Areas.Administration.Data.DataProcessor.ImportDto
{
    public class ImportKidDto
    {


        [Required]
        public string KIDnumber { get; set; }
        [Required]
        public string Group { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string PositionName { get; set; }


    }


}

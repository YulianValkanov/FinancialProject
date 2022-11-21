using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinancialServices.Areas.Administration.Data.DataProcessor.ImportDto
{
    public class ImportPersonsDto
    {


        [Required]
        public long IdEgn { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

    }



}

using System.ComponentModel.DataAnnotations;

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

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FinancialServices.Models.Persons
{
    public class AddPersonViewModel
    {
       
        [Required(ErrorMessage = "ЕГН е задължително")]
        public long IdEgn { get; set; }

        [Required(ErrorMessage = "Името е задължително")]
        public string FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? LastName { get; set; }

    }
}

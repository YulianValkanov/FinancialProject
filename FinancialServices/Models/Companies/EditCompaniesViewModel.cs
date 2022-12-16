﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Data.Models;

namespace FinancialServices.Models.Companies
{
    public class EditCompaniesViewModel
    {
        [Required(ErrorMessage = "EGN е задължително")]
        public long IdEik { get; set; }

        [Required(ErrorMessage = "Името е задължително")]
        public string CompanyName { get; set; }

        public string? AddressCompany { get; set; }

        public string? AddressActivity { get; set; }

        public string? KidNumber { get; set; }

        public string? Representing { get; set; }

        public string? TypeRepresenting { get; set; }

        public string? TypeCompany { get; set; }

        public string? ContactName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Status { get; set; }





    }
}

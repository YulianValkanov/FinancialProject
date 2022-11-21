using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinancialServices.Areas.Administration.Data.DataProcessor.ImportDto
{
    public class ImportCompaniesDto
    {

       
        [Required]
        public int IdEik { get; set; }

        [Required]
        public string CompanyName { get; set; }
    
        public string AddressCompany { get; set; }
    
        public string AddressActivity { get; set; }

        public string KidNumber { get; set; }
        public string Representing { get; set; }
        public string TypeRepresenting { get; set; }
        public string TypeCompany { get; set; }

        [DefaultValue(0.0)]
        public double NumberEmployees2021 { get; set; } = 0.0;
        [DefaultValue(0.0)]
        public double AnnualTurnover2021 { get; set; }
        [DefaultValue(0.0)]
        public double Assets2021 { get; set; }
        [DefaultValue(0.0)]
        public double NumberEmployees2020 { get; set; }
        [DefaultValue(0.0)]
        public double AnnualTurnover2020 { get; set; }
        [DefaultValue(0.0)]
        public double Assets2020 { get; set; }
        [DefaultValue(0.0)]

        public double NumberEmployees2019 { get; set; }
        [DefaultValue(0.0)]
        public double AnnualTurnover2019 { get; set; }
        [DefaultValue(0.0)]
        public double Assets2019 { get; set; }
        [DefaultValue(0.0)]

        public string NameContacts { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }


    }

}

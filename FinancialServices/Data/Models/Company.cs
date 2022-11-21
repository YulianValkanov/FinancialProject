using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static FinancialServices.Constants.Constants.Companies;


namespace Theatre.Data.Models
{
    public class Company
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdEik { get; set; }


        [Required]
        [StringLength(MaxLenghtCompanyName, MinimumLength = MinLenghtCompanyName)]
        public string? CompanyName { get; set; }

     
        public string? AddressCompany { get; set; }


        public string? AddressActivity { get; set; }


        public string? KidNumber { get; set; }

        [ForeignKey("KidNumber")]
        public Kid? Kid { get; set; }
 

        public string? Representing { get; set; }

        public string? TypeRepresenting { get; set; }

        public string? TypeCompany { get; set; }

        public string? ContactName { get; set; }

        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string?    Email { get; set; }

        public string? Status { get; set; }


        public  List<MapingCompanyReport> MapingCompanyReports { get; set; } = new List<MapingCompanyReport>();

        public  List<MapingManager> MapingManagers { get; set; }= new List<MapingManager>(); 

        public  List<MapingOwnerPerson> MapingOwnerPersons { get; set; } = new List<MapingOwnerPerson>();    

        public  List<MapingOwnerCompany> MapingOwnerCompanies { get; set; } = new List<MapingOwnerCompany>();


    }
}

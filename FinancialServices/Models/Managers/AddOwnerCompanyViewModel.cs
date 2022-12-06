using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Data.Models;
using FinancialServices.Data.Models;

namespace FinancialServices.Models
{
    public class AddOwnerCompanyViewModel
    {
     
        public long IdEik { get; set; }

        public long OwnerEik { get; set; }

        public double Persent { get; set; }


    }
}

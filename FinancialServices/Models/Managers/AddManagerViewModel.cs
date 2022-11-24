using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Data.Models;
using FinancialServices.Data.Models;

namespace FinancialServices.Models
{
    public class AddManagerViewModel
    {
     
        public long IdEik { get; set; }

        public long IdEgn { get; set; }


    }
}

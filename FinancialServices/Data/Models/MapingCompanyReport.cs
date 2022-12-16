using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using FinancialServices.Data.Models;

namespace Theatre.Data.Models
{
    public class MapingCompanyReport
    {

       

        public long IdEik { get; set; }

        [ForeignKey(nameof(IdEik))]
        public Company Company { get; set; }



        public int ReportId { get; set; }

        [ForeignKey(nameof(ReportId))]
        public ReportData ReportData { get; set; }


      
    }
}
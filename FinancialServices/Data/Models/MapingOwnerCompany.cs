
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace Theatre.Data.Models
{
    public class MapingOwnerCompany
    {

     
   
        public long IdEik { get; set; }
        [ForeignKey(nameof(IdEik))]
        public  Company Company { get; set; }


      
        public long IdEikOwner { get; set; }

       

        public double Persent { get; set; }
    }
}

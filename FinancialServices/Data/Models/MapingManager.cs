using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace Theatre.Data.Models
{
    public class MapingManager
    {

       
        public long IdEik { get; set; }

        [ForeignKey(nameof(IdEik))]
        public  Company Company { get; set; }


       
        public long IdEgn { get; set; }

        [ForeignKey(nameof(IdEgn))]
        public Person Person { get; set; }

      

    }
}

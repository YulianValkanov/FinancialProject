using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
    public class Kid
    {


        [Key]
        public string KidNumber { get; set; } 

        public string Group { get; set; }

        public string GroupName { get; set; }

        public string PositionName { get; set; } 

       
        public List<Company> Companies { get; set; }=new List<Company>();

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace Theatre.Data.Models
{
    public  class Person
    {
  

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdEgn { get; set; }

     
        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? LastName { get; set; }


        public  List<MapingManager> MapingManagers { get; set; }=new List<MapingManager>();

        public  List<MapingOwnerPerson> MapingOwnerPersons { get; set; }= new List<MapingOwnerPerson>();

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinancialServices.Areas.Administration.Data.DataProcessor.ImportDto
{
    public class ImportMapingOwnersCompany
    {


        [Required]
        public int IdEik { get; set; }
        [Required]
        public int IdEikOwner { get; set; }
        [Required]
        public double Persent { get; set; }

    }



}

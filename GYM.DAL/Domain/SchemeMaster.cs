﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace GYM.DAL.Domain
{
    public class SchemeMaster
    {
        
        public int SchemeID { get; set; }  
        
        public string SchemeName { get; set; }
        public int Createdby { get; set; }
        public DateTime Createddate { get; set; }

        public string schemebit { get; set; }
    }
}

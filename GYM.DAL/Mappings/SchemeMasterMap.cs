using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM.DAL.Domain;
using Microsoft.EntityFrameworkCore;

namespace GYM.DAL.Mappings
{
    public class SchemeMasterMap
    {
        public SchemeMasterMap(EntityTypeBuilder<SchemeMaster> entityBuilder)
        {
            entityBuilder.ToTable("SchemeMaster"); 
            entityBuilder.HasKey(u => u.SchemeID);                    
        }
    }
}

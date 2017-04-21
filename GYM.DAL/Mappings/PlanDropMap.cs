using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYM.DAL.Mappings
{
    public class PlanDropMap
    {
        public PlanDropMap(EntityTypeBuilder<PlanDrop> entityBuilder)
        {
            entityBuilder.ToTable("PlanMaster");
            entityBuilder.HasKey(p => p.PlanId);
        }
    }
}

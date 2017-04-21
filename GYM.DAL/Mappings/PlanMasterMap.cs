using GYM.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.DAL.Mappings
{
    public class PlanMasterMap
    {
        public PlanMasterMap(EntityTypeBuilder<PlanMaster> entityBuilder)
        {
            entityBuilder.ToTable("PlanMaster");
            entityBuilder.HasKey(p => p.PlanId);
            entityBuilder.Ignore(p => p.PeriodId);           
            entityBuilder.Ignore(p => p.ServicetaxNo);
            entityBuilder.Ignore(p => p.ServicetaxAmout);
        }
    }
}

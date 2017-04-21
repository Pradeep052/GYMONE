using GYM.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.DAL.Mappings
{
    public class MemberRegistrationMap
    {
        public MemberRegistrationMap(EntityTypeBuilder<MemberRegistration> entityBuilder)
        {
            entityBuilder.ToTable("MemberRegistration");
            entityBuilder.HasKey(m => m.MemId);            
        }
    }
}

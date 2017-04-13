using GYM.DAL.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GYM.DAL.Mappings
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<Users> entityBuilder)
        {
            entityBuilder.ToTable("Users");
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Ignore(u => u.FullNameOne);
        }
    }
}

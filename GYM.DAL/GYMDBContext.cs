﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GYM.DAL.Domain;
using GYM.DAL.Mappings;

namespace GYM.DAL
{
    public class GYMDBContext : DbContext
    {
        public GYMDBContext(DbContextOptions<GYMDBContext> options) : base(options) { }
        
        public DbSet<Users> User { get; set; }


        #region Model Building
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new UserMap(builder.Entity<Users>());
        }

        #endregion
    }
}
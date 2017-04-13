using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GYM.DAL.Repository.Interfaces;
using GYM.DAL.Repository;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GYM.DAL.Extensions
{
    public static class GymDataAccessServiceCollectionExtensions
    {
        public static IServiceCollection AddGymServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IGYMRepository, GYMRepository>();

            services.AddEntityFramework()
                .AddEntityFrameworkSqlServer()
                .AddDbContext<GYMDBContext>(options => options.UseSqlServer(config["ConnectionStrings:GymDBConnection"]));
            return services;
        }
    }
}

using Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OhcDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OhcDatabase")));

            services.AddScoped<IOhcDbContext>(provider => provider.GetService<OhcDbContext>());
        }
    }
}

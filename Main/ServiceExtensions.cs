using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Main
{
    public static class ServiceExtensions
    {

        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextPool<DataContext>(
                    options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }
    }
}

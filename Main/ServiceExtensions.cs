using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Interfaces;
using LoggerService;
using Repository;

namespace Main
{
    public static class ServiceExtensions
    {

        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextPool<DataContext>(
                    options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Business Inspection API", Version = "v1" });
            });

        }

        public static void ConfigureRepositoryHub(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryHub, RepositoryHub>();
        }
    }
}

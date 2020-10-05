using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.Net.Http.Headers;

namespace Main
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureLoggerService();
            services.AddDbContextPool<DataContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.ConfigureSwagger();
            services.ConfigureRepositoryHub();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers(mvcOptions =>
                   mvcOptions.EnableEndpointRouting = false)
               .AddNewtonsoftJson();
                
            services.AddOData();

            services.AddMvc(op =>
            {
                foreach (var formatter in op.OutputFormatters
                    .OfType<ODataOutputFormatter>()
                    .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.mock-odata"));
                }
                foreach (var formatter in op.InputFormatters
                    .OfType<ODataInputFormatter>()
                    .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.mock-odata"));
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/api/error");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseMvc(routeBuilder =>
            //{
            //    routeBuilder.Select().Filter();
            //    routeBuilder.EnableDependencyInjection();
            //    routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            //});
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Business Inspection API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.Select().Filter().OrderBy().Count().Expand().MaxTop(10);
                endpoints.EnableDependencyInjection();
                endpoints.MapODataRoute("odata", "odata", GetEdmModel());
            });


        }

            IEdmModel GetEdmModel()
            {
                var odataBuilder = new ODataConventionModelBuilder();
                odataBuilder.EntitySet<Business>("Businesses");
                odataBuilder.EntitySet<Inspection>("Inspections");

                return odataBuilder.GetEdmModel();
            }
    }
}

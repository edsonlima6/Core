using Domain.Interfaces.Repositories;
using InfraCoreDapper;
using InfraCoreEF.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.IoC
{
    public static class ServiceCollectionExtension
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940


        public static void AddConfigureServices( this IServiceCollection services)
        {
            var Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile("Appsetting.json")
                                                   .Build();

            string connString = Configuration.GetConnectionString("connectionStringWin");
            
            
            services.AddDbContext<ContextBD>(opt => opt.UseSqlServer(connString));
            services.AddTransient<IRepositoryBase, InfraCoreDapper.RepositoryBase>();
            services.AddTransient<IUnitOfWorkCore, UnitOfWorkCore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}

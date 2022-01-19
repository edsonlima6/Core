using Application.Handles;
using Application.Interfaces;
using Domain.Interfaces.Repositories;
using InfraCoreDapper;
using InfraCoreEF.Db;
using InfraCoreSQLite;
using InfraCoreSQLite.Repositories;
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

        /// <summary>
        ///  This method is responsible for setting the services up globally
        /// </summary>
        /// <param name="services">It must implement IServiceCollection interface</param>
        public static void AddConfigureServices(this IServiceCollection services, string db = "SQL")
        {
            var Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile("Appsetting.json")
                                                   .Build();

            string connString = Configuration.GetConnectionString("connectionStringLinux");

            if (db != "SQL")
            { 
                string sqliteConn = Configuration.GetConnectionString("SqliteConnectionString");
                services.AddDbContext<SQLiteDbContext>(opt => opt.UseSqlite(sqliteConn));
            }
            else
                services.AddDbContext<ContextBD>(opt => opt.UseSqlServer(connString, opt => opt.EnableRetryOnFailure()));



            services.AddTransient<IUserRepository, InfraCoreEF.Repositories.UserRepository>();
            services.AddTransient<IRepositoryBase, InfraCoreDapper.RepositoryBase>();

            services.AddTransient<IUnitOfWorkCore, UnitOfWorkCore>();
            //services.AddTransient<IUserRepository, UserSqliteRepo>();


            // Handlers 
            services.AddScoped<IUserHandler, UserHandler>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">It must implement IApplicationBuilder interface</param>
        /// <param name="env">It must implement IWebHostEnvironment interface</param>
        public static void Configure( this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}

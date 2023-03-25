using System.Buffers;
using Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SpaServices;
using Hangfire;
using Hangfire.SqlServer;
using MediatR;
using System.Reflection;

namespace SkyNetApiCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigureServices();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SkyNetApiCore", Version = "v1" });
            });

            // Add Hangfire services. https://docs.hangfire.io/en/latest/getting-started/aspnet-core-applications.html
            services.AddHangfire(configuration => configuration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(Configuration.GetConnectionString("connectionStringWin"), new SqlServerStorageOptions
                    {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        DisableGlobalLocks = true
                    }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            var appAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Application"));

            //if (appAssembly != null)
            //{
            //    // Mediatr 
            //    services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            //}

            //services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IBackgroundJobClient backgroundJobs, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkyNetApiCore v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });

            app.UseSpa((ISpaBuilder spaBuilder) =>
            {
                spaBuilder.Options.SourcePath = "wwwroot";

                //if (env.IsDevelopment())
                //    spaBuilder.UseProxyToSpaDevelopmentServer(baseUri: "http://localhost:4200");
            });

            app.UseHangfireDashboard();
           // backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));

        }
    }
}

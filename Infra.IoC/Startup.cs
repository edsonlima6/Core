using Application.DomainEvents;
using Application.Handles;
using Application.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Specifications;
using InfraCoreDapper;
using InfraCoreEF.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;

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
        public static void AddConfigureServices(this IServiceCollection services, string connStrg = "")
        {
            if (string.IsNullOrEmpty(connStrg))
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true)
                    .Build();

                connStrg = configuration.GetConnectionString("connectionStringWin");
            }

            // Use scoped lifetime for DbContext and EF repositories so they share the same instance per request
            services.AddDbContext<ContextBD>(opt => opt.UseSqlServer(connStrg, opt =>
            {
                opt.EnableRetryOnFailure();
                opt.MigrationsAssembly(typeof(ContextBD).Assembly.FullName);
            }));

            services.AddScoped<IUserRepository, InfraCoreEF.Repositories.UserRepository>();
            services.AddScoped<ISupplierRepository, InfraCoreEF.Repositories.SupplierRepository>();
            services.AddScoped<IOutboxMessageRepository, InfraCoreEF.Repositories.OutboxMessageRepository>();
            services.AddTransient<IRepositoryBase, InfraCoreDapper.RepositoryBase>();

            // Register the EF UnitOfWork implementation (scoped) so it shares the same ContextBD
            services.AddScoped<Domain.Interfaces.Repositories.IUnitOfWorkCore, UnitOfWorkCore>();
            services.AddScoped<InfraCoreEF.Db.UnitOfWorkEF>();
            services.AddScoped<Domain.Interfaces.Repositories.IUnitOfWork>(sp => sp.GetRequiredService<InfraCoreEF.Db.UnitOfWorkEF>());
            services.AddScoped<InfraCoreEF.Db.IUnitOfWork>(sp => sp.GetRequiredService<InfraCoreEF.Db.UnitOfWorkEF>());
            services.AddScoped<DomainNotification>();
            services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();
            services.AddDomainEventHandlers(typeof(CreateSupplierHander).Assembly);


            // Handlers 
            services.AddScoped<IUserHandler, UserHandler>();
        }

        private static void AddDomainEventHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            var handlerInterfaceType = typeof(IDomainEventHandler<>);

            var handlerTypes = assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsClass && !type.IsAbstract)
                .Select(type => new
                {
                    HandlerType = type,
                    Interfaces = type.GetInterfaces()
                        .Where(interfaceType => interfaceType.IsGenericType &&
                            interfaceType.GetGenericTypeDefinition() == handlerInterfaceType)
                });

            foreach (var handlerType in handlerTypes)
            {
                foreach (var handlerInterface in handlerType.Interfaces)
                {
                    services.AddScoped(handlerInterface, handlerType.HandlerType);
                }
            }
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

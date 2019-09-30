using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetDocsCore2_1.Model;
using Infra.Context;
using Infra.CrossCutting2.Context;
using Infra.CrossCutting2.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TeleHelp.Application.Interface;
using TeleHelp.Application.Services;
using MyBI.Domain1.Services;
using MyBI.Domain1.Interfaces.Services;
using MyBI.Domain1.Interfaces.Repositories;
using Infra.Repository;
using AutoMapper;

namespace NetDocsCore2_1
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
            services.AddAutoMapper(typeof(DomainToView), typeof(ViewToDomain));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("BaseIdentity"))
            services.AddDbContext<ContextDB>();

            // Configurando o uso da classe de contexto para
            // acesso às tabelas do ASP.NET Identity Core
            // permitir a recuperação de seus objetos via injeção de
            // dependências 
            services.AddIdentity<ApplicationUser, IdentRole>()
                    .AddEntityFrameworkStores<ContextCrossDB>()
                    .AddDefaultTokenProviders();

            SetupJWT(services);

            services.AddSingleton<ContextCrossDB>();
            services.AddSingleton<ApplicationUser>();
            services.AddSingleton<IdentRole>();        
    

            SetupDomainEntities(services);


            services.AddCors(options =>
                            {
                                options.AddPolicy("MyAllowSpecificOrigins",
                                builder =>
                                {
                                    builder.WithOrigins("http://localhost")
                                                        .AllowAnyHeader()
                                                        .AllowAnyMethod()
                                                        .AllowAnyOrigin();
                                });
                            });

             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("MyAllowSpecificOrigins");

        }

        private void SetupJWT(IServiceCollection services)
        {
            try
            {
                var signingConfigurations = new SigningConfigurations();
                services.AddSingleton(signingConfigurations);

                var tokenConfigurations = new TokenConfigurations();
                new ConfigureFromConfigurationOptions<TokenConfigurations>(Configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);
                services.AddSingleton(tokenConfigurations);

                services.AddAuthentication(authOptions =>
                {
                    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(bearerOptions =>
                                            {
                                                var paramsValidation = bearerOptions.TokenValidationParameters;
                                                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                                                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                                                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                            
                                                // Valida a assinatura de um token recebido
                                                paramsValidation.ValidateIssuerSigningKey = true;
                            
                                                // Verifica se um token recebido ainda é válido
                                                paramsValidation.ValidateLifetime = true;
                            
                                                // Tempo de tolerância para a expiração de um token (utilizado
                                                // caso haja problemas de sincronismo de horário entre diferentes
                                                // computadores envolvidos no processo de comunicação)
                                                paramsValidation.ClockSkew = TimeSpan.Zero;
                                            });

                // Ativa o uso do token como forma de autorizar o acesso
                // a recursos deste projeto
                services.AddAuthorization(auth =>
                {
                    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser().Build());
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetupDomainEntities(IServiceCollection services)
        {
            services.AddSingleton<IEmpresaApplication, EmpresaApllication>();
            services.AddSingleton<IEmpresaService, EmpresaService>();
            services.AddSingleton<IEmpresaRepository, EmpresaRepository>();
        }
    }
}

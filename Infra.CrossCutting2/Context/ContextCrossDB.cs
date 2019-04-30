using Infra.CrossCutting2.Application;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.CrossCutting2.Context
{
    public class ContextCrossDB : IdentityDbContext<ApplicationUser>
    {
        public ContextCrossDB()
        {
            
        }
        public ContextCrossDB(DbContextOptions<ContextCrossDB> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {  
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Gotta;Trusted_Connection=True;");
            }
        }

    }
}

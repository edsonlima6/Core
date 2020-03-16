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
             optionsBuilder.UseSqlServer(@"Server=10.21.237.23\SQLEXPRESS2,50946;Initial Catalog=NetDocs;Persist Security Info=False;User ID=sa;Password=I10easttoLA;MultipleActiveResultSets=True");
            // if (!optionsBuilder.IsConfigured)
            //  { 
            //     @"Server=10.21.237.23\SQLEXPRESS2,50946;Initial Catalog=NetDocs;Persist Security Info=False;User ID=sa;Password=I10easttoLA;MultipleActiveResultSets=True"

            //}

        }

    }
}

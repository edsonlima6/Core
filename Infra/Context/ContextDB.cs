using Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using TeleHelp.Domain.Entities;

namespace Infra.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB()
        {
            Database.Migrate();
        }
     
        public DbSet<Cliente> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //(localdb)\mssqllocaldb
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Tome;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfiguration(new ClientMap());


            //Base
            base.OnModelCreating(modelBuilder);
        }


    }
}

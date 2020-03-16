using Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using MyBI.Domain1.Entities;

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
            //@"Server=10.21.237.23\SQLEXPRESS2,50946;Initial Catalog=NetDocs;Persist Security Info=False;User ID=sa;Password=I10easttoLA;MultipleActiveResultSets=True"
            optionsBuilder.UseSqlServer(@"Server=10.21.237.23\SQLEXPRESS2,50946;Initial Catalog=NetDocs;Persist Security Info=False;User ID=sa;Password=I10easttoLA;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());

            //Base
            base.OnModelCreating(modelBuilder);
        }


    }
}

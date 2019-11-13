using System;
using Infra.CrossCutting2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.CrossCutting2.Application
{
    public class BackContext : IDesignTimeDbContextFactory<ContextCrossDB>
    {
        public ContextCrossDB CreateDbContext(string[] args)
        {
            // Linux Connection @"Server=localhost,1401;Initial Catalog=NetDocs;Persist Security Info=False;User ID=sa;Password=I10easttoLA;MultipleActiveResultSets=True"
            // Server=(localdb)\MSSQLLocalDB;Initial Catalog=Gotta;Trusted_Connection=True;
            var optionsBuilder = new DbContextOptionsBuilder<ContextCrossDB>();
            optionsBuilder.UseSqlServer(@"Server=DGF36808\SQLEXPRESS;Initial Catalog=NetDocs;Persist Security Info=False;User ID=sa;Password=I10easttoLA;MultipleActiveResultSets=True;");
            return new ContextCrossDB(optionsBuilder.Options);
        }

    }
}

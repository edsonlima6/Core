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
            // @"Server=10.21.237.23\SQLEXPRESS2,50946;Initial Catalog=NetDocs;Persist Security Info=False;User ID=sa;Password=I10easttoLA;MultipleActiveResultSets=True"
            var optionsBuilder = new DbContextOptionsBuilder<ContextCrossDB>();
            optionsBuilder.UseSqlServer(@"Server=10.21.237.23\SQLEXPRESS2,50946;Initial Catalog=NetDocs;Persist Security Info=False;User ID=sa;Password=I10easttoLA;MultipleActiveResultSets=True");
            return new ContextCrossDB(optionsBuilder.Options);
        }

    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreSQLite
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(m => m.Id);

            //modelBuilder.ApplyConfiguration(new BlogMap());
            //modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string conWin = @"Data Source=Db/SkyNet.db";
        //    optionsBuilder.UseSqlite(conWin);

        //}


    }
}

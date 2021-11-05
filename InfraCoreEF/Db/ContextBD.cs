using Dapper.Contrib.Extensions;
using Domain.Entities;
using InfraCoreEF.Mapping;
//using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreEF.Db
{
    public class ContextBD : DbContext
    {
        public ContextBD(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
        public ContextBD()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server=localhost,1433;Database=student;User Id=sa;Password=!Abcd123;
            //string conLinux = @"Server=localhost,1433;Database=CoreBase;User Id=SA;Password=I10easttoLA";
            //Password=YourSTRONG!Passw0rd"  @""

            string conWin = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CoreBase;Integrated Security=True;";
            optionsBuilder.UseSqlServer(conWin);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BlogMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }


    }

    public class BlogMap : IEntityTypeConfiguration<Blog>
    {

        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blog");
            builder.HasKey(c => c.BlogId);
            builder.Property(c => c.Url).HasColumnType("varchar(14)");
            builder.Property(c => c.Name).HasColumnType("varchar(14)");
        }
    }

    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        [Computed]
        public List<Post> Posts { get; } = new List<Post>();
    }

    [Table("Post")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }

        [Computed]
        public Blog Blog { get; set; }
    }
}

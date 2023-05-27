using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreEF.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Password).HasColumnType("varchar(12)")
                                             .HasMaxLength(12);

            builder.Property(u => u.Email).HasColumnType("varchar(100)");
            builder.Property(u => u.Name).HasColumnType("varchar(120)");
            builder.Property(u => u.LastName).HasColumnType("varchar(120)");
            builder.Property(u => u.CreatedON).HasColumnType("datetime").HasDefaultValueSql("Getdate()").IsRequired();
            builder.Property(u => u.UpdatedOn).HasColumnType("datetime").IsRequired(false);
            builder.Property(u => u.EntryDate).HasColumnType("datetime").IsRequired(false);
            builder.Property(u => u.ExitDate).HasColumnType("datetime").IsRequired(false);

        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraCoreEF.Mapping
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.CompanyName).HasColumnType("varchar(180)").IsRequired();
            builder.Property(s => s.Description).HasColumnType("varchar(500)");
            builder.Property(s => s.ServicePrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(s => s.PaymentInstallments).IsRequired();
            builder.Property(s => s.CreatedON).HasColumnType("datetime").IsRequired();
            builder.Property(s => s.UpdatedOn).HasColumnType("datetime").IsRequired(false);
            builder.Property(s => s.EntryDate).HasColumnType("datetime").IsRequired(false);
            builder.Property(s => s.ExitDate).HasColumnType("datetime").IsRequired(false);
        }
    }
}

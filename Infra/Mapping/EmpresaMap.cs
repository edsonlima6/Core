using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBI.Domain1.Entities;

namespace Infra.Mapping
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
          public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(c => c.idRazaoSocial);
            builder.Property(c => c.sRazaoSocial).HasColumnType("varchar(400)");
            builder.Property(c => c.dtCadastro)//.HasColumnType("datetime")
                                               .HasDefaultValueSql("getdate()")
                                               .IsRequired(true);
        }
    }

    
}
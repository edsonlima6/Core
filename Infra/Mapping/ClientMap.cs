using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeleHelp.Domain.Entities;

namespace Infra.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.IdCliente);
            builder.Property(c => c.InscricaoEstadual).HasColumnType("varchar(14)");
            builder.Property(c => c.RazaoSocial).HasColumnType("varchar(250)");
            builder.Property(c => c.Rg).HasColumnType("varchar(12)");
            builder.Property(c => c.CpfCnpj).HasColumnType("varchar(12)");
        }
    }
}

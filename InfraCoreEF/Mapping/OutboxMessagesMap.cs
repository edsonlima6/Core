using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraCoreEF.Mapping
{
    internal class OutboxMessagesMap : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.ToTable("OutboxMessages");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Type).HasColumnType("varchar(100)");
            builder.Property(c => c.Payload).HasColumnType("nvarchar(max)");
        }
    }
}

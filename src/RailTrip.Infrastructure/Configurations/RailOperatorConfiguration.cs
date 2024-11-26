using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailTrip.Domain.Entities;

namespace RailTrip.Infrastructure.Configurations
{
    internal sealed class RailOperatorConfiguration : IEntityTypeConfiguration<RailOperator>
    {
        public void Configure(EntityTypeBuilder<RailOperator> builder)
        {
            builder.ToTable("RailOperators");

            builder.HasKey(railOperator => railOperator.Id);

            builder.Property(railOperator => railOperator.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(railOperator => railOperator.ContactNumber)
                .HasMaxLength(50);

            builder.Property(railOperator => railOperator.OperatingRegion)
                .HasMaxLength(200);
        }
    }
}

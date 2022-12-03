using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Blockchain.Domain;

namespace Blockchain.Persistance.EntityTypesConfiguration
{
    public  class TrackerPointConfiguration : IEntityTypeConfiguration<TrackerPoint>
    {
        public void Configure(EntityTypeBuilder<TrackerPoint> builder)
        {
            builder.HasKey(point => point.Id);
            builder.HasIndex(point => point.Id).IsUnique();
            builder.Property(point => point.latitude).IsRequired();
            builder.Property(point => point.longitude).IsRequired();
            builder.Property(point => point.timestamp).IsRequired();
        }
    }
}

using Blockchain.Application.Infrastructure;
using Blockchain.Persistance.EntityTypesConfiguration;
using Blockchain.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blockchain.Persistance
{
    public class TrackerPointDbContext : DbContext, ITrackerPointDbContext
    {
        public DbSet<TrackerPoint> TrackerPoints { get; set; }

        public TrackerPointDbContext(DbContextOptions<TrackerPointDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TrackerPointConfiguration());
            base.OnModelCreating(builder);
        }
    }
}

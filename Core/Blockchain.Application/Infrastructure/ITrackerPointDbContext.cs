using Blockchain.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Blockchain.Application.Infrastructure
{
    public interface ITrackerPointDbContext
    {
        DbSet<TrackerPoint> TrackerPoints { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

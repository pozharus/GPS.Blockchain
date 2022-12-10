using Blockchain.Application.Points.Queries.GetPointList;
using Blockchain.Application.Points.Queries.GetPointDetails;
using Blockchain.Domain;

namespace Blockchain.Application.Infrastructure
{
    public interface ITrackerPointDbContext
    {
        PointListVm getAll();
        PointDetailsVm getPointById(GetPointDetailsQuery request);
        string createPoint(TrackerPoint point);
    }
}

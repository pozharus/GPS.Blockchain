using Blockchain.Application.Infrastructure;
using Blockchain.Application.Points.Queries.GetPointDetails;
using Blockchain.Application.Points.Queries.GetPointList;
using Blockchain.Domain;
using System.Collections.Generic;

namespace Blockchain.Persistance
{
    public class TrackerPointDbContext : ITrackerPointDbContext
    {

        public PointListVm getAll()
        {
            var assets = BigChainDbAPI.getAssets("2022");
            var pointsQuery = new PointListVm();
            pointsQuery.Points = new List<PointListLookupDto>();
            foreach (var item in assets)
            {
                var point = new PointListLookupDto();
                point.id = item.Data.id;
                point.timestamp = item.Data.timestamp;
                point.latitude = item.Data.latitude;
                point.longitude = item.Data.longitude;
                pointsQuery.Points.Add(point);
            }
            return pointsQuery;
        }
        public PointDetailsVm getPointById(GetPointDetailsQuery request)
        {
            var assets = BigChainDbAPI.getAssets(request.Id.ToString());
            PointDetailsVm point = new PointDetailsVm();
            foreach (var item in assets)
            {
                if(item.Data.id == request.Id)
                {
                    point.transactionId = item.Id;
                    point.timestamp = item.Data.timestamp;
                    point.latitude = item.Data.latitude;
                    point.longitude = item.Data.longitude;
                    point.altitude = item.Data.altitude;
                    point.speed = item.Data.speed;
                    point.satelites = item.Data.satelites;
                    point.delusionOfPresition = item.Data.delusionOfPresition;
                    point.horizontalDelusionOfPresition = item.Data.horizontalDelusionOfPresition;
                    point.verticalDelusionOfPresition = item.Data.verticalDelusionOfPresition;
                }
                break;
            }
            return point;
        }
        public string createPoint(TrackerPoint point)
        {
            var asset = BigChainDbAPI.createAsset(point);
            var metadata = BigChainDbAPI.createMetadata("Our secret metadata");
            var transaction = BigChainDbAPI.createTransaction(asset, metadata);
            var response = BigChainDbAPI.sendTransaction(transaction);
            return response.Data.Id;
        }
    }
}

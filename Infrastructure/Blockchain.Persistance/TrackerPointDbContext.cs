using Blockchain.Application.Infrastructure;
using Blockchain.Application.Points.Queries.GetPointDetails;
using Blockchain.Application.Points.Queries.GetPointList;
using Blockchain.Domain;
using System.Collections.Generic;
using System.Linq;

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
            var asset = BigChainDbAPI.getAssets(request.Id.ToString());
            return new PointDetailsVm
            {
                transactionId = asset.First().Id,
                timestamp = asset.First().Data.timestamp,
                latitude = asset.First().Data.latitude,
                longitude = asset.First().Data.longitude,
                altitude = asset.First().Data.altitude,
                speed = asset.First().Data.speed,
                satelites = asset.First().Data.satelites,
                delusionOfPresition = asset.First().Data.delusionOfPresition,
                horizontalDelusionOfPresition = asset.First().Data.horizontalDelusionOfPresition,
                verticalDelusionOfPresition = asset.First().Data.verticalDelusionOfPresition
            };
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

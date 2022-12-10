using MediatR;
using System;
using Blockchain.Domain;
using System.Threading;
using System.Threading.Tasks;
using Blockchain.Application.Infrastructure;

namespace Blockchain.Application.Points.Commands.CreatePoint
{
    public class CreatePointCommandHandler
        : IRequestHandler<CreatePointCommand, string>
    {
        private readonly ITrackerPointDbContext _dbContext;

        public CreatePointCommandHandler(ITrackerPointDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<string> Handle(CreatePointCommand request, CancellationToken cancellationToken)
        {
            var point = new TrackerPoint
            {
                //yyyy.mm.dd.yy.mm.ss
                id = Guid.NewGuid().ToString(),
                timestamp = new DateTime(int.Parse(request.timestamp.Split('.')[0]), int.Parse(request.timestamp.Split('.')[1]),
                                     int.Parse(request.timestamp.Split('.')[2]), int.Parse(request.timestamp.Split('.')[3]),
                                     int.Parse(request.timestamp.Split('.')[4]), int.Parse(request.timestamp.Split('.')[5])),
                latitude = request.latitude,
                longitude = request.longitude,
                altitude = request.altitude,
                speed = request.speed,
                satelites = request.satelites,
                delusionOfPresition = request.delusionOfPresition,
                horizontalDelusionOfPresition = request.horizontalDelusionOfPresition,
                verticalDelusionOfPresition = request.verticalDelusionOfPresition
            };

            _dbContext.createPoint(point);
            return point.id;
        }
    }
}

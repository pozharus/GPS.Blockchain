using Blockchain.Application.Infrastructure;
using MediatR;
using System;
using Blockchain.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Blockchain.Application.Points.Commands.CreatePoint
{
    public class CreatePointCommandHandler
        : IRequestHandler<CreatePointCommand, Guid>
    {
        private readonly ITrackerPointDbContext _dbContext;

        public CreatePointCommandHandler(ITrackerPointDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreatePointCommand request,
            CancellationToken cancellationToken)
        {
            var point = new TrackerPoint
            {
                Id = Guid.NewGuid(),
                //yyyy.mm.dd.yy.mm.ss
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

            //Currently store object to LiteSQL DB
            //TODO: Store object in ETH blockchain
            await _dbContext.TrackerPoints.AddAsync(point, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return point.Id;
        }
    }
}

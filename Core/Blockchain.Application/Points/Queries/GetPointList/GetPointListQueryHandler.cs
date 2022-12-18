using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Blockchain.Application.Infrastructure;

namespace Blockchain.Application.Points.Queries.GetPointList
{
     public class GetPointListQueryHandler
        : IRequestHandler<GetPointListQuery, PointListVm>
    {
        private readonly ITrackerPointDbContext _dbContext;

        public GetPointListQueryHandler(ITrackerPointDbContext dbContext) =>
            (_dbContext) = (dbContext);

        public async Task<PointListVm> Handle(GetPointListQuery request,
            CancellationToken cancellationToken)
        {
            return _dbContext.getAll();
        }
    }
}

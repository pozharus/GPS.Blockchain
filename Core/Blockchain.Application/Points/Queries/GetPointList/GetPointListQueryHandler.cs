using AutoMapper;
using Blockchain.Application.Infrastructure;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Blockchain.Application.Points.Queries.GetPointList
{
     public class GetPointListQueryHandler
        : IRequestHandler<GetPointListQuery, PointListVm>
    {
        private readonly ITrackerPointDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPointListQueryHandler(ITrackerPointDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PointListVm> Handle(GetPointListQuery request,
            CancellationToken cancellationToken)
        {
            var pointsQuery = await _dbContext.TrackerPoints
                .ProjectTo<PointListLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PointListVm { Points = pointsQuery };
        }
    }
}

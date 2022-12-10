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
        private readonly IMapper _mapper;

        public GetPointListQueryHandler(ITrackerPointDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PointListVm> Handle(GetPointListQuery request,
            CancellationToken cancellationToken)
        {
            return _dbContext.getAll();
        }
    }
}

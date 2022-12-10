using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Notes.Application.Common.Exceptions;
using Blockchain.Domain;
using Blockchain.Application.Infrastructure;

namespace Blockchain.Application.Points.Queries.GetPointDetails
{
    public class GetPointDetailsQueryHandler
        : IRequestHandler<GetPointDetailsQuery, PointDetailsVm>
    {
        private readonly ITrackerPointDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPointDetailsQueryHandler(ITrackerPointDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PointDetailsVm> Handle(GetPointDetailsQuery request,
                    CancellationToken cancellationToken)
        {
            var point = _dbContext.getPointById(request);
            return _mapper.Map<PointDetailsVm>(point);
        }
    }
}

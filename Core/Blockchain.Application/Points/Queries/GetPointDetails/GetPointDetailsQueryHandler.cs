using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Blockchain.Application.Infrastructure;
using Blockchain.Domain;

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
            var entity = await _dbContext.TrackerPoints
                .FirstOrDefaultAsync(point =>
                point.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(TrackerPoint), request.Id);
            }

            return _mapper.Map<PointDetailsVm>(entity);
        }
    }
}

using MediatR;
using System;

namespace Blockchain.Application.Points.Queries.GetPointDetails
{
    public class GetPointDetailsQuery : IRequest<PointDetailsVm>
    {
        public Guid Id { get; set; }
    }
}

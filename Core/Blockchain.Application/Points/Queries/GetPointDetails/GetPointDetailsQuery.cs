using MediatR;

namespace Blockchain.Application.Points.Queries.GetPointDetails
{
    public class GetPointDetailsQuery : IRequest<PointDetailsVm>
    {
        public string Id { get; set; }
    }
}

using MediatR;

namespace Blockchain.Application.Points.Commands.CreatePoint
{
    public class CreatePointCommand : IRequest<string>
    {
        public string id { get; set; }
        public string timestamp { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float altitude { get; set; }
        public float speed { get; set; }
        public int satelites { get; set; }
        public float delusionOfPresition { get; set; }
        public float horizontalDelusionOfPresition { get; set; }
        public float verticalDelusionOfPresition { get; set; }
    }
}

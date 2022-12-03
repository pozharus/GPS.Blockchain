using System.Collections.Generic;

namespace Blockchain.Application.Points.Queries.GetPointList
{
    public class PointListVm
    {
        public IList<PointListLookupDto> Points { get; set; }
    }
}

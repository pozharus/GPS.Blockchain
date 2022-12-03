using System;

namespace Blockchain.Domain
{
    /*
     * Represent a simple point is getting from GPS hardware
     */
    public class TrackerPoint
    {
        public Guid Id { get; set; }
        public DateTime timestamp { get; set; }
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

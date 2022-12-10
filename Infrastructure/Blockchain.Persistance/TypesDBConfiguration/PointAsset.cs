using Newtonsoft.Json;
using System;

namespace Blockchain.Persistance.TypesDBConfiguration
{
    [Serializable]
    public class PointAsset
    {
        [JsonProperty]
        public string id { get; set; }
        [JsonProperty]
        public DateTime timestamp { get; set; }
        [JsonProperty]
        public float latitude { get; set; }
        [JsonProperty]
        public float longitude { get; set; }
        [JsonProperty]
        public float altitude { get; set; }
        [JsonProperty]
        public float speed { get; set; }
        [JsonProperty]
        public int satelites { get; set; }
        [JsonProperty]
        public float delusionOfPresition { get; set; }
        [JsonProperty]
        public float horizontalDelusionOfPresition { get; set; }
        [JsonProperty]
        public float verticalDelusionOfPresition { get; set; }
    }
}

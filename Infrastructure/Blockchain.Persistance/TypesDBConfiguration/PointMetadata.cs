using Newtonsoft.Json;
using System;

namespace Blockchain.Persistance.TypesDBConfiguration
{
    [Serializable]
    public class PointMetadata
    {
        [JsonProperty]
        public string msg { get; set; }
    }
}

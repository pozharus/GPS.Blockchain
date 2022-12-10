using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Persistance.TypesDBConfiguration
{
    [Serializable]
    public class PointMetadata
    {
        [JsonProperty]
        public string msg { get; set; }
    }
}

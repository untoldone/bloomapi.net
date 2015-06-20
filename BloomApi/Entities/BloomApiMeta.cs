using Newtonsoft.Json;
using System.Collections.Generic;

namespace BloomApi.Entities
{
    public class BloomApiMeta
    {
        [JsonProperty(PropertyName = "messages")]
        public List<string> Messages { get; set; }
        [JsonProperty(PropertyName = "rowCount")]
        public int RowCount { get; set; }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace BloomApi.Entities
{
    public class BloomApiSourcesResponse
    {
        [JsonProperty(PropertyName = "meta")]
        public BloomApiMeta Meta { get; set; }

        [JsonProperty(PropertyName = "result")]
        public List<BloomApiSource> Result { get; set; }
    }
}

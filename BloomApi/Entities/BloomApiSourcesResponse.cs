using Newtonsoft.Json;
using System.Collections.Generic;

namespace BloomApi.Entities
{
    public class BloomApiSourcesResponse
    {
        [JsonProperty(PropertyName = "meta")]
        public BloomApiMeta Meta { get; set; }

        [JsonProperty(PropertyName = "result")]
        public IEnumerable<BloomApiSource> Result { get; set; }
    }
}

using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace BloomApi.Entities
{
    public class BloomApiSearchResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "meta")]
        public BloomApiMeta Meta { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "result")]
        public List<JObject> Result { get; set; }
    }
}

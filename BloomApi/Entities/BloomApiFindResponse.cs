using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BloomApi.Entities
{
    public class BloomApiFindResponse
    {
        [JsonProperty(PropertyName = "meta")]
        public BloomApiMeta Meta { get; set; }

        [JsonProperty(PropertyName = "result")]
        public JObject Result { get; set; }
    }
}

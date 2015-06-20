using Newtonsoft.Json;
using System;

namespace BloomApi.Entities
{
    public class BloomApiSource
    {
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "checked")]

        public DateTime Checked { get; set; }

        [JsonProperty(PropertyName = "updated")]
        public DateTime Updated { get; set; }
    }
}

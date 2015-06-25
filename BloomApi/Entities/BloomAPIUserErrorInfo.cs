using Newtonsoft.Json;

namespace BloomApi.Entities
{
    public class BloomAPIUserErrorInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}

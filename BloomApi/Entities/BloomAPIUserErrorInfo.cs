using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

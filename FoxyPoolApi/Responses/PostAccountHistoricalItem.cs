using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    public class PostAccountHistoricalItem
    {
        [JsonProperty("shares")]
        public uint Shares { get; set; }

        [JsonProperty("shareCount")]
        public uint ShareCount { get; set; }

        [JsonProperty("ec")]
        public decimal Ec { get; set; }

        [JsonProperty("difficulty")]
        public uint Difficulty { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}

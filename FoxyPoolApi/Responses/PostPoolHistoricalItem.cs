using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    public class PostPoolHistoricalItem
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("blocks")]
        public long Blocks { get; set; }

        [JsonProperty("effort")]
        public decimal? Effort { get; set; }

        [JsonProperty("poolEcInTib")]
        public string PoolEcInTib { get; set; } = string.Empty;

        [JsonProperty("networkCapacityInTib")]
        public string NetworkCapacityInTib { get; set; } = string.Empty;
    }
}

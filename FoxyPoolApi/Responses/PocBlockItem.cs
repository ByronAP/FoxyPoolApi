using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class PocBlockItem
    {
        [JsonProperty("height")]
        public ulong Height { get; set; }

        [JsonProperty("baseTarget")]
        public string? BaseTarget { get; set; }

        [JsonProperty("netDiff")]
        public string? NetDiff { get; set; }

        [JsonProperty("hash")]
        public string? Hash { get; set; }

        [JsonProperty("reward")]
        public decimal Reward { get; set; }
    }
}

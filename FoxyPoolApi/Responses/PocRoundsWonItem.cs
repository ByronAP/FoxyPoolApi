using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    public class PocRoundsWonItem
    {
        [JsonProperty("block")]
        public PocBlockItem? Block { get; set; }

        [JsonProperty("bestAccount")]
        public PocBestAccountItem? BestAccount { get; set; }

        [JsonProperty("winner")]
        public PocWinnerItem? Winner { get; set; }

        [JsonProperty("poolCapacity")]
        public PocPoolCapacityItem? PoolCapacity { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("distributed")]
        public bool Distributed { get; set; }

        [JsonProperty("distributionRatio", NullValueHandling = NullValueHandling.Ignore)]
        public string? DistributionRatio { get; set; }

        [JsonProperty("won")]
        public bool Won { get; set; }
    }
}

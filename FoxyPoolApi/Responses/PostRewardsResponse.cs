using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PostRewardsResponse
    {
        [JsonProperty("recentlyWonBlocks")]
        public List<RecentlyWonBlock>? RecentlyWonBlocks { get; set; }

        [JsonProperty("dailyRewardPerPiB")]
        public decimal DailyRewardPerPiB { get; set; }

        [JsonProperty("averageEffort")]
        public decimal AverageEffort { get; set; }
    }

    public class RecentlyWonBlock
    {
        [JsonProperty("winner")]
        public BlockWinner? Winner { get; set; }

        [JsonProperty("isRewardClaimed")]
        public bool IsRewardClaimed { get; set; }

        [JsonProperty("height")]
        public ulong Height { get; set; }

        [JsonProperty("hash")]
        public string? Hash { get; set; }

        [JsonProperty("reward")]
        public decimal Reward { get; set; }

        [JsonProperty("networkSpaceInTib")]
        public string? NetworkSpaceInTib { get; set; }

        [JsonProperty("effort")]
        public decimal Effort { get; set; }

        [JsonProperty("distributed")]
        public bool Distributed { get; set; }

        [JsonProperty("distributionRatio")]
        public string? DistributionRatio { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class BlockWinner
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("payoutAddress")]
        public string? PayoutAddress { get; set; }
    }
}

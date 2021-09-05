using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    public class PostConfigResponse
    {
        [JsonProperty("poolUrl")]
        public Uri PoolUrl { get; set; }

        [JsonProperty("blockExplorerBlockUrlTemplate")]
        public string BlockExplorerBlockUrlTemplate { get; set; }

        [JsonProperty("blockExplorerCoinUrlTemplate")]
        public string BlockExplorerCoinUrlTemplate { get; set; }

        [JsonProperty("blockExplorerAddressUrlTemplate")]
        public string BlockExplorerAddressUrlTemplate { get; set; }

        [JsonProperty("blockRewardDistributionDelay")]
        public uint BlockRewardDistributionDelay { get; set; }

        [JsonProperty("blocksPerDay")]
        public uint BlocksPerDay { get; set; }

        [JsonProperty("defaultDistributionRatio")]
        public string DefaultDistributionRatio { get; set; }

        [JsonProperty("historicalTimeInMinutes")]
        public uint HistoricalTimeInMinutes { get; set; }

        [JsonProperty("minimumPayout")]
        public decimal MinimumPayout { get; set; }

        [JsonProperty("onDemandPayoutFee")]
        public decimal OnDemandPayoutFee { get; set; }

        [JsonProperty("poolFee")]
        public decimal PoolFee { get; set; }

        [JsonProperty("coin")]
        public string Coin { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("isTestnet")]
        public bool IsTestnet { get; set; }

        [JsonProperty("poolAddress")]
        public string PoolAddress { get; set; }

        [JsonProperty("poolName")]
        public string PoolName { get; set; }

        [JsonProperty("farmingUrl")]
        public Uri FarmingUrl { get; set; }

        public static PostConfigResponse FromJson(string json) => JsonConvert.DeserializeObject<PostConfigResponse>(json);
    }
}

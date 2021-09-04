﻿using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    public class ConfigResponse
    {
        [JsonProperty("poolUrl")]
        public Uri PoolUrl { get; set; }

        [JsonProperty("blockExplorerBlockUrlTemplate")]
        public Uri BlockExplorerBlockUrlTemplate { get; set; }

        [JsonProperty("blockExplorerCoinUrlTemplate")]
        public Uri BlockExplorerCoinUrlTemplate { get; set; }

        [JsonProperty("blockExplorerAddressUrlTemplate")]
        public Uri BlockExplorerAddressUrlTemplate { get; set; }

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

        public static ConfigResponse FromJson(string json) => JsonConvert.DeserializeObject<ConfigResponse>(json);
    }
}

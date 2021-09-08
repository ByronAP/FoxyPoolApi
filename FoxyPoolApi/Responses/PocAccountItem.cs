using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PocAccountItem
    {
        [JsonProperty("pending")]
        public string? Pending { get; set; }

        [JsonProperty("ec")]
        public decimal Ec { get; set; }

        [JsonProperty("ecShare")]
        public decimal EcShare { get; set; }

        [JsonProperty("payoutAddress")]
        public string? PayoutAddress { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("distributionRatio")]
        public string? DistributionRatio { get; set; }

        [JsonProperty("miner")]
        public List<PocMinerItem>? Miner { get; set; }

        [JsonProperty("plotter")]
        public List<PocPlotterItem>? Plotter { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("deadlines")]
        public ulong Deadlines { get; set; }

        [JsonProperty("software", NullValueHandling = NullValueHandling.Ignore)]
        public string? Software { get; set; }

        [JsonProperty("connection", NullValueHandling = NullValueHandling.Ignore)]
        public string? Connection { get; set; }

        [JsonProperty("lastSubmissionHeight", NullValueHandling = NullValueHandling.Ignore)]
        public ulong LastSubmissionHeight { get; set; } = 0;

        [JsonProperty("isDeprecatedUrl", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDeprecatedUrl { get; set; } = false;

        [JsonProperty("reportedCapacity")]
        public ulong ReportedCapacity { get; set; }

        [JsonProperty("pledge", NullValueHandling = NullValueHandling.Ignore)]
        public string? Pledge { get; set; }

        [JsonProperty("pledgeShare", NullValueHandling = NullValueHandling.Ignore)]
        public decimal PledgeShare { get; set; } = 0m;
    }
}

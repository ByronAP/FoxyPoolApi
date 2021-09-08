using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PocPoolResponse
    {
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("ec")]
        public decimal Ec { get; set; }

        [JsonProperty("estimatedCapacity")]
        public uint EstimatedCapacity { get; set; }

        [JsonProperty("accountCount")]
        public uint AccountCount { get; set; }

        [JsonProperty("accounts")]
        public List<PocAccountItem>? Accounts { get; set; }

        [JsonProperty("payouts")]
        public List<PocPayoutItem>? Payouts { get; set; }

        [JsonProperty("pledge")]
        public decimal Pledge { get; set; }

        [JsonProperty("requiredPledge")]
        public uint RequiredPledge { get; set; }

        [JsonProperty("availableMiningBalance")]
        public decimal AvailableMiningBalance { get; set; }

        [JsonProperty("roundsWon")]
        public List<PocRoundsWonItem>? RoundsWon { get; set; }

        [JsonProperty("totalCapacity")]
        public ulong TotalCapacity { get; set; }

        [JsonProperty("distributionRatios")]
        public List<string>? DistributionRatios { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        // TODO: event type
        [JsonProperty("events")]
        public List<object>? Events { get; set; }

        [JsonProperty("pledgeSum")]
        public string? PledgeSum { get; set; }

        [JsonProperty("dailyRewardPerPiB")]
        public decimal DailyRewardPerPiB { get; set; }
    }
}

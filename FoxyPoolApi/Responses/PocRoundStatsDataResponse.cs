using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    public class PocRoundStatsDataResponse
    {
        [JsonProperty("round")]
        public PocRoundItem? Round { get; set; }

        [JsonProperty("roundStart")]
        public DateTimeOffset RoundStart { get; set; }

        [JsonProperty("bestDeadline")]
        public ulong? BestDeadline { get; set; }

        [JsonProperty("bestDeadlineMiner")]
        public ulong? BestDeadlineMiner { get; set; }

        [JsonProperty("bestSubmission")]
        public ulong? BestSubmission { get; set; }

        public static PocRoundStatsDataResponse FromJson(string json) => JsonConvert.DeserializeObject<PocRoundStatsDataResponse>(json);
    }
}

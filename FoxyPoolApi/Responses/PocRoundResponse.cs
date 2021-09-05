using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    public class PocRoundResponse
    {
        [JsonProperty("round")]
        public PocRoundItem Round { get; set; }

        [JsonProperty("roundStart")]
        public DateTimeOffset RoundStart { get; set; }

        [JsonProperty("bestDeadline")]
        public ulong BestDeadline { get; set; }

        [JsonProperty("bestDeadlineMiner")]
        public string BestDeadlineMiner { get; set; }

        [JsonProperty("bestSubmission")]
        public PocBestSubmissionItem BestSubmission { get; set; }

        public static PocRoundResponse FromJson(string json) => JsonConvert.DeserializeObject<PocRoundResponse>(json);
    }
}

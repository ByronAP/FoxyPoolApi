using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class PocMiningInfoResponse
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("baseTarget")]
        public uint BaseTarget { get; set; }

        [JsonProperty("generationSignature")]
        public string? GenerationSignature { get; set; }

        [JsonProperty("targetDeadline")]
        public ulong TargetDeadline { get; set; }

        [JsonProperty("averageCommitment", NullValueHandling = NullValueHandling.Ignore)]
        public string? AverageCommitment { get; set; }

        public static PocMiningInfoResponse FromJson(string json) => JsonConvert.DeserializeObject<PocMiningInfoResponse>(json);
    }
}

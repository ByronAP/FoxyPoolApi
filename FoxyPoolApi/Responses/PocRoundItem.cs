using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class PocRoundItem
    {
        [JsonProperty("height")]
        public ulong Height { get; set; }

        [JsonProperty("baseTarget")]
        public uint BaseTarget { get; set; }

        [JsonProperty("generationSignature")]
        public string GenerationSignature { get; set; }

        [JsonProperty("targetDeadline")]
        public ulong TargetDeadline { get; set; }
    }
}

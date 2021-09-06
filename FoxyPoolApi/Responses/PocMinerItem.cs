using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class PocMinerItem
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("software")]
        public string? Software { get; set; }

        [JsonProperty("connection")]
        public string? Connection { get; set; }

        [JsonProperty("reportedCapacity")]
        public uint ReportedCapacity { get; set; } = 0;

        [JsonProperty("lastSubmissionHeight")]
        public ulong LastSubmissionHeight { get; set; } = 0;

        [JsonProperty("isDeprecatedUrl")]
        public bool IsDeprecatedUrl { get; set; } = false;
    }
}

using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class PocPlotterItem
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("id")]
        public string? PlotterId { get; set; }

        [JsonProperty("lastSubmissionHeight")]
        public ulong LastSubmissionHeight { get; set; } = 0;
    }
}

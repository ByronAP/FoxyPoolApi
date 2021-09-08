using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class StatusItem
    {
        [JsonProperty("indicator")]
        public IncidentImpact Indicator { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}

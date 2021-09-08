using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    public class IncidentUpdateItem
    {
        [JsonProperty("body")]
        public string? Body { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("display_at")]
        public DateTimeOffset DisplayAt { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("incident_id")]
        public string? IncidentId { get; set; }

        [JsonProperty("status")]
        public IncidentStatus Status { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

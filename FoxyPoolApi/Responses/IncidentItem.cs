using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class IncidentItem
    {
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("impact")]
        public IncidentImpact Impact { get; set; }

        [JsonProperty("incident_updates")]
        public List<IncidentUpdateItem>? IncidentUpdates { get; set; }

        [JsonProperty("monitoring_at")]
        public DateTimeOffset? MonitoringAt { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("page_id")]
        public string? PageId { get; set; }

        [JsonProperty("resolved_at")]
        public DateTimeOffset? ResolvedAt { get; set; }

        [JsonProperty("shortlink")]
        public string? Shortlink { get; set; }

        [JsonProperty("status")]
        public IncidentStatus Status { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("scheduled_for", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ScheduledFor { get; set; }

        [JsonProperty("scheduled_until", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ScheduledUntil { get; set; }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PoolSummaryResponse
    {
        [JsonProperty("page")]
        public PageItem? Page { get; set; }

        [JsonProperty("components")]
        public List<ComponentItem>? Components { get; set; }

        [JsonProperty("incidents")]
        public List<IncidentItem>? Incidents { get; set; }

        [JsonProperty("scheduled_maintenances")]
        public List<IncidentItem>? ScheduledMaintenances { get; set; }

        [JsonProperty("status")]
        public StatusItem? Status { get; set; }
    }
}

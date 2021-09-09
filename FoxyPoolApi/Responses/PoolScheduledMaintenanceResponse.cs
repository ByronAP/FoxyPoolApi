using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PoolScheduledMaintenanceResponse
    {
        [JsonProperty("page")]
        public PageItem? Page { get; set; }

        [JsonProperty("scheduled_maintenances")]
        public List<IncidentItem>? ScheduledMaintenances { get; set; }
    }
}

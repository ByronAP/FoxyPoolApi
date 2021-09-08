using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PoolIncidentsResponse
    {
        [JsonProperty("page")]
        public PageItem? Page { get; set; }

        [JsonProperty("incidents")]
        public List<IncidentItem>? Incidents { get; set; }
    }
}

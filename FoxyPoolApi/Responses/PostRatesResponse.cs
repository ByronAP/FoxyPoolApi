using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PostRatesResponse
    {
        [JsonProperty("rates")]
        public Dictionary<string, decimal>? Rates { get; set; }

        [JsonProperty("currencies")]
        public List<string>? Currencies { get; set; }
    }
}

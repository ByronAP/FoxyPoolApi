using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class RatesResponse
    {
        [JsonProperty("rates")]
        public Dictionary<string, decimal> Rates { get; set; }

        [JsonProperty("currencies")]
        public List<string> Currencies { get; set; }

        public static RatesResponse FromJson(string json) => JsonConvert.DeserializeObject<RatesResponse>(json);
    }
}

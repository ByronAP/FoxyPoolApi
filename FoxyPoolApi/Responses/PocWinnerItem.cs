using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class PocWinnerItem
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("plotter")]
        public string Plotter { get; set; }

        [JsonProperty("deadline")]
        public string Deadline { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}

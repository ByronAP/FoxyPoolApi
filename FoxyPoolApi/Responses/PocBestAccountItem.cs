using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class PocBestAccountItem
    {
        [JsonProperty("bestDeadline")]
        public string? BestDeadline { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}

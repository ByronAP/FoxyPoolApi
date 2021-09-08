using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class PoolStatusResponse
    {
        [JsonProperty("page")]
        public PageItem? Page { get; set; }

        [JsonProperty("status")]
        public StatusItem? Status { get; set; }

        public static PoolStatusResponse FromJson(string json) => JsonConvert.DeserializeObject<PoolStatusResponse>(json);
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PoolComponentsResponse
    {
        [JsonProperty("page")]
        public PageItem? Page { get; set; }

        [JsonProperty("components")]
        public List<ComponentItem>? Components { get; set; }
    }
}

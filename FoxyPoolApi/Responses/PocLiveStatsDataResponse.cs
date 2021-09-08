using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PocLiveStatsDataResponse
    {
        [JsonProperty("currentSubmissions")]
        public Dictionary<string, PocCurrentSubmissionItem>? CurrentSubmissions { get; set; }

        public static PocLiveStatsDataResponse FromJson(string json) => JsonConvert.DeserializeObject<PocLiveStatsDataResponse>(json);
    }
}

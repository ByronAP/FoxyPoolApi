using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PocLiveResponse
    {
        [JsonProperty("currentSubmissions")]
        public Dictionary<string, PocCurrentSubmissionItem>? CurrentSubmissions { get; set; }
    }
}

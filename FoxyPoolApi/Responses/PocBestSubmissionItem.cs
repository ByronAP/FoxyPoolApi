using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class PocBestSubmissionItem
    {
        [JsonProperty("plotterId")]
        public string PlotterId { get; set; }

        [JsonProperty("height")]
        public ulong Height { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("deadline")]
        public string Deadline { get; set; }
    }
}

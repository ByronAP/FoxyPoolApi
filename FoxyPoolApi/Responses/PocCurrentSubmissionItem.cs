using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class PocCurrentSubmissionItem
    {
        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("deadline")]
        public ulong Deadline { get; set; }
    }
}

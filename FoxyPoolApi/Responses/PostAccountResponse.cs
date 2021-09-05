using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    public class PostAccountResponse
    {
        [JsonProperty("difficulty")]
        public uint Difficulty { get; set; }

        [JsonProperty("pending")]
        public string Pending { get; set; }

        [JsonProperty("ec")]
        public decimal Ec { get; set; }

        [JsonProperty("shares")]
        public uint Shares { get; set; }

        [JsonProperty("poolPublicKey")]
        public string PoolPublicKey { get; set; }

        [JsonProperty("payoutAddress")]
        public string PayoutAddress { get; set; }

        [JsonProperty("distributionRatio")]
        public string DistributionRatio { get; set; }

        [JsonProperty("collateral")]
        public string Collateral { get; set; }

        [JsonProperty("lastAcceptedPartialAt")]
        public DateTimeOffset LastAcceptedPartialAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("minimumPayout")]
        public decimal MinimumPayout { get; set; } = 0.01m;

        public static PostAccountResponse FromJson(string json) => JsonConvert.DeserializeObject<PostAccountResponse>(json);
    }
}

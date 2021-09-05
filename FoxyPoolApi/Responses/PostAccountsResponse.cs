using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PostAccountsResponse
    {
        [JsonProperty("topAccounts")]
        public List<TopAccount> TopAccounts { get; set; }

        [JsonProperty("accountsWithShares")]
        public uint AccountsWithShares { get; set; }

        [JsonProperty("ecSum")]
        public decimal EcSum { get; set; }

        public static PostAccountsResponse FromJson(string json) => JsonConvert.DeserializeObject<PostAccountsResponse>(json);
    }

    public class TopAccount
    {
        [JsonProperty("pending")]
        public string Pending { get; set; }

        [JsonProperty("ec")]
        public decimal Ec { get; set; }

        [JsonProperty("payoutAddress")]
        public string PayoutAddress { get; set; }

        [JsonProperty("distributionRatio")]
        public string DistributionRatio { get; set; }

        [JsonProperty("collateral", NullValueHandling = NullValueHandling.Ignore)]
        public string Collateral { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}

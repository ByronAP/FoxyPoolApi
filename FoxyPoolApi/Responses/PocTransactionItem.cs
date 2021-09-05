using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PocTransactionItem
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("txId")]
        public string TxId { get; set; }

        [JsonProperty("payoutAmounts")]
        public Dictionary<string, string> PayoutAmounts { get; set; }
    }
}

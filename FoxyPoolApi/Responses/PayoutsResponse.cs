using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PayoutsResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        public static PayoutsResponse[] FromJson(string json) => JsonConvert.DeserializeObject<PayoutsResponse[]>(json);
    }

    public class Transaction
    {
        [JsonProperty("coinIds")]
        public List<string> CoinIds { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("txId")]
        public string TxId { get; set; }

        [JsonProperty("payoutAmounts")]
        public Dictionary<string, string> PayoutAmounts { get; set; }
    }
}

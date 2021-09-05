using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PostPayoutsResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        public static PostPayoutsResponse[] FromJson(string json) => JsonConvert.DeserializeObject<PostPayoutsResponse[]>(json);
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

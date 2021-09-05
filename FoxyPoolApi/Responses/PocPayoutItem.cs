using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PocPayoutItem
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("transactions")]
        public List<PocTransactionItem> Transactions { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

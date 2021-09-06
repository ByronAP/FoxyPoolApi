using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PostPoolResponse
    {
        [JsonProperty("height")]
        public ulong Height { get; set; }

        [JsonProperty("difficulty")]
        public uint Difficulty { get; set; }

        [JsonProperty("receivedAt")]
        public DateTimeOffset ReceivedAt { get; set; }

        [JsonProperty("networkSpaceInTiB")]
        public string? NetworkSpaceInTiB { get; set; }

        [JsonProperty("balance")]
        public string? Balance { get; set; }

        [JsonProperty("events")]
        public List<PoolEvent>? Events { get; set; }
    }

    public class PoolEvent
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("startedAt")]
        public DateTimeOffset StartedAt { get; set; }

        [JsonProperty("endedAt")]
        public DateTimeOffset EndedAt { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("payload")]
        public Payload? Payload { get; set; }
    }

    public class Payload
    {
        [JsonProperty("extraReward")]
        public decimal ExtraReward { get; set; }

        [JsonProperty("creditedCount")]
        public uint CreditedCount { get; set; }

        [JsonProperty("totalCount")]
        public uint TotalCount { get; set; }
    }
}

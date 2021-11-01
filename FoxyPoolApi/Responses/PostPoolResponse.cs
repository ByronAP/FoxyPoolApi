// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PostPoolResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PostPoolResponse.
    /// </summary>
    public class PostPoolResponse
    {
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        [JsonProperty("height")]
        public ulong Height { get; set; }

        /// <summary>
        /// Gets or sets the difficulty.
        /// </summary>
        /// <value>The difficulty.</value>
        [JsonProperty("difficulty")]
        public uint Difficulty { get; set; }

        /// <summary>
        /// Gets or sets the received at.
        /// </summary>
        /// <value>The received at.</value>
        [JsonProperty("receivedAt")]
        public DateTimeOffset ReceivedAt { get; set; }

        /// <summary>
        /// Gets or sets the network space in ti b.
        /// </summary>
        /// <value>The network space in ti b.</value>
        [JsonProperty("networkSpaceInTiB")]
        public string? NetworkSpaceInTiB { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        [JsonProperty("balance")]
        public string? Balance { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>The events.</value>
        [JsonProperty("events")]
        public List<PoolEvent>? Events { get; set; }
    }

    /// <summary>
    /// Class PoolEvent.
    /// </summary>
    public class PoolEvent
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the started at.
        /// </summary>
        /// <value>The started at.</value>
        [JsonProperty("startedAt")]
        public DateTimeOffset StartedAt { get; set; }

        /// <summary>
        /// Gets or sets the ended at.
        /// </summary>
        /// <value>The ended at.</value>
        [JsonProperty("endedAt")]
        public DateTimeOffset EndedAt { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public string? State { get; set; }

        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        /// <value>The payload.</value>
        [JsonProperty("payload")]
        public Payload? Payload { get; set; }
    }

    /// <summary>
    /// Class Payload.
    /// </summary>
    public class Payload
    {
        /// <summary>
        /// Gets or sets the extra reward.
        /// </summary>
        /// <value>The extra reward.</value>
        [JsonProperty("extraReward")]
        public decimal ExtraReward { get; set; }

        /// <summary>
        /// Gets or sets the credited count.
        /// </summary>
        /// <value>The credited count.</value>
        [JsonProperty("creditedCount")]
        public uint CreditedCount { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>The total count.</value>
        [JsonProperty("totalCount")]
        public uint TotalCount { get; set; }
    }
}

// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-17-2021
//
// Last Modified By : bapen
// Last Modified On : 10-31-2021
// ***********************************************************************
// <copyright file="PostAccountHistoricalItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PostAccountHistoricalItem.
    /// </summary>
    public class PostAccountHistoricalItem
    {
        /// <summary>
        /// Gets or sets the shares.
        /// </summary>
        /// <value>The shares.</value>
        [JsonProperty("shares")]
        public uint Shares { get; set; }

        /// <summary>
        /// Gets or sets the share count.
        /// </summary>
        /// <value>The share count.</value>
        [JsonProperty("shareCount")]
        public uint ShareCount { get; set; }

        /// <summary>
        /// Gets or sets the stale shares count.
        /// </summary>
        /// <value>The share count.</value>
        [JsonProperty("staleShares")]
        public uint StaleShares { get; set; }

        /// <summary>
        /// Gets or sets the invalid shares count.
        /// </summary>
        /// <value>The share count.</value>
        [JsonProperty("invalidShares")]
        public uint InvalidShares { get; set; }

        /// <summary>
        /// Gets or sets the ec.
        /// </summary>
        /// <value>The ec.</value>
        [JsonProperty("ec")]
        public decimal Ec { get; set; }

        /// <summary>
        /// Gets or sets the difficulty.
        /// </summary>
        /// <value>The difficulty.</value>
        [JsonProperty("difficulty")]
        public uint Difficulty { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}

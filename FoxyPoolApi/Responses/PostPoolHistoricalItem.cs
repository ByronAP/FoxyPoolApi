// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 10-01-2021
//
// Last Modified By : bapen
// Last Modified On : 10-01-2021
// ***********************************************************************
// <copyright file="PostPoolHistoricalItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PostPoolHistoricalItem.
    /// </summary>
    public class PostPoolHistoricalItem
    {
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the blocks.
        /// </summary>
        /// <value>The blocks.</value>
        [JsonProperty("blocks")]
        public long Blocks { get; set; }

        /// <summary>
        /// Gets or sets the effort.
        /// </summary>
        /// <value>The effort.</value>
        [JsonProperty("effort")]
        public decimal? Effort { get; set; }

        /// <summary>
        /// Gets or sets the pool ec in tib.
        /// </summary>
        /// <value>The pool ec in tib.</value>
        [JsonProperty("poolEcInTib")]
        public string PoolEcInTib { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the network capacity in tib.
        /// </summary>
        /// <value>The network capacity in tib.</value>
        [JsonProperty("networkCapacityInTib")]
        public string NetworkCapacityInTib { get; set; } = string.Empty;
    }
}

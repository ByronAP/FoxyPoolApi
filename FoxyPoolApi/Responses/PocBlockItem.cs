// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocBlockItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocBlockItem.
    /// </summary>
    public class PocBlockItem
    {
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        [JsonProperty("height")]
        public ulong Height { get; set; }

        /// <summary>
        /// Gets or sets the base target.
        /// </summary>
        /// <value>The base target.</value>
        [JsonProperty("baseTarget")]
        public string? BaseTarget { get; set; }

        /// <summary>
        /// Gets or sets the net difference.
        /// </summary>
        /// <value>The net difference.</value>
        [JsonProperty("netDiff")]
        public string? NetDiff { get; set; }

        /// <summary>
        /// Gets or sets the hash.
        /// </summary>
        /// <value>The hash.</value>
        [JsonProperty("hash")]
        public string? Hash { get; set; }

        /// <summary>
        /// Gets or sets the reward.
        /// </summary>
        /// <value>The reward.</value>
        [JsonProperty("reward")]
        public decimal Reward { get; set; }
    }
}

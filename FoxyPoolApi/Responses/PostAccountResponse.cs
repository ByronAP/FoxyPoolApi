// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PostAccountResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PostAccountResponse.
    /// </summary>
    public class PostAccountResponse
    {
        /// <summary>
        /// Gets or sets the difficulty.
        /// </summary>
        /// <value>The difficulty.</value>
        [JsonProperty("difficulty")]
        public uint Difficulty { get; set; }

        /// <summary>
        /// Gets or sets the pending.
        /// </summary>
        /// <value>The pending.</value>
        [JsonProperty("pending")]
        public string? Pending { get; set; }

        /// <summary>
        /// Gets or sets the ec.
        /// </summary>
        /// <value>The ec.</value>
        [JsonProperty("ec")]
        public decimal Ec { get; set; }

        /// <summary>
        /// Gets or sets the shares.
        /// </summary>
        /// <value>The shares.</value>
        [JsonProperty("shares")]
        public uint Shares { get; set; }

        /// <summary>
        /// Gets or sets the pool public key.
        /// </summary>
        /// <value>The pool public key.</value>
        [JsonProperty("poolPublicKey")]
        public string? PoolPublicKey { get; set; }

        /// <summary>
        /// Gets or sets the payout address.
        /// </summary>
        /// <value>The payout address.</value>
        [JsonProperty("payoutAddress")]
        public string? PayoutAddress { get; set; }

        /// <summary>
        /// Gets or sets the distribution ratio.
        /// </summary>
        /// <value>The distribution ratio.</value>
        [JsonProperty("distributionRatio")]
        public string? DistributionRatio { get; set; }

        /// <summary>
        /// Gets or sets the collateral.
        /// </summary>
        /// <value>The collateral.</value>
        [JsonProperty("collateral")]
        public string? Collateral { get; set; }

        /// <summary>
        /// Gets or sets the last accepted partial at.
        /// </summary>
        /// <value>The last accepted partial at.</value>
        [JsonProperty("lastAcceptedPartialAt")]
        public DateTimeOffset LastAcceptedPartialAt { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the minimum payout.
        /// </summary>
        /// <value>The minimum payout.</value>
        [JsonProperty("minimumPayout")]
        public decimal MinimumPayout { get; set; } = 0.01m;
    }
}

// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 10-31-2021
// ***********************************************************************
// <copyright file="PostConfigResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PostConfigResponse.
    /// </summary>
    public class PostConfigResponse
    {
        /// <summary>
        /// Gets or sets the pool URL.
        /// </summary>
        /// <value>The pool URL.</value>
        [JsonProperty("poolUrl")]
        public string? PoolUrl { get; set; }

        /// <summary>
        /// Gets or sets the block explorer block URL template.
        /// </summary>
        /// <value>The block explorer block URL template.</value>
        [JsonProperty("blockExplorerBlockUrlTemplate")]
        public string? BlockExplorerBlockUrlTemplate { get; set; }

        /// <summary>
        /// Gets or sets the block explorer coin URL template.
        /// </summary>
        /// <value>The block explorer coin URL template.</value>
        [JsonProperty("blockExplorerCoinUrlTemplate")]
        public string? BlockExplorerCoinUrlTemplate { get; set; }

        /// <summary>
        /// Gets or sets the block explorer address URL template.
        /// </summary>
        /// <value>The block explorer address URL template.</value>
        [JsonProperty("blockExplorerAddressUrlTemplate")]
        public string? BlockExplorerAddressUrlTemplate { get; set; }

        /// <summary>
        /// Gets or sets the block reward distribution delay.
        /// </summary>
        /// <value>The block reward distribution delay.</value>
        [JsonProperty("blockRewardDistributionDelay")]
        public uint BlockRewardDistributionDelay { get; set; }

        /// <summary>
        /// Gets or sets the blocks per day.
        /// </summary>
        /// <value>The blocks per day.</value>
        [JsonProperty("blocksPerDay")]
        public uint BlocksPerDay { get; set; }

        /// <summary>
        /// Gets or sets the default distribution ratio.
        /// </summary>
        /// <value>The default distribution ratio.</value>
        [JsonProperty("defaultDistributionRatio")]
        public string? DefaultDistributionRatio { get; set; }

        /// <summary>
        /// Gets or sets the historical time in minutes.
        /// </summary>
        /// <value>The historical time in minutes.</value>
        [JsonProperty("historicalTimeInMinutes")]
        public uint HistoricalTimeInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the minimum payout.
        /// </summary>
        /// <value>The minimum payout.</value>
        [JsonProperty("minimumPayout")]
        public decimal MinimumPayout { get; set; }

        /// <summary>
        /// Gets or sets the on demand payout fee.
        /// </summary>
        /// <value>The on demand payout fee.</value>
        [JsonProperty("onDemandPayoutFee")]
        public decimal OnDemandPayoutFee { get; set; }

        /// <summary>
        /// Gets or sets the pool fee.
        /// </summary>
        /// <value>The pool fee.</value>
        [JsonProperty("poolFee")]
        public decimal PoolFee { get; set; }

        /// <summary>
        /// Gets or sets the coin.
        /// </summary>
        /// <value>The coin.</value>
        [JsonProperty("coin")]
        public string? Coin { get; set; }

        /// <summary>
        /// Gets or sets the ticker.
        /// </summary>
        /// <value>The ticker.</value>
        [JsonProperty("ticker")]
        public string? Ticker { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [JsonProperty("version")]
        public string? Version { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is testnet.
        /// </summary>
        /// <value><c>true</c> if this instance is testnet; otherwise, <c>false</c>.</value>
        [JsonProperty("isTestnet")]
        public bool IsTestnet { get; set; }

        /// <summary>
        /// Gets or sets the pool address.
        /// </summary>
        /// <value>The pool address.</value>
        [JsonProperty("poolAddress")]
        public string? PoolAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of the pool.
        /// </summary>
        /// <value>The name of the pool.</value>
        [JsonProperty("poolName")]
        public string? PoolName { get; set; }

        /// <summary>
        /// Gets or sets the farming URL.
        /// </summary>
        /// <value>The farming URL.</value>
        [JsonProperty("farmingUrl")]
        public string? FarmingUrl { get; set; }
    }
}
